using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using NinetySix.Server.Models.Entities.Auth;
using NinetySix.Server.Models.Entities.Common.Identity;
using NinetySix.Server.Models.Repositories;

namespace NinetySix.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IDatabaseRepository _databaseRepository;

    public AuthController(UserManager<User> userManager, IDatabaseRepository databaseRepository)
    {
        _userManager = userManager;
        _databaseRepository = databaseRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUser user)
    {
        User appUser = new User
        {
            UserName = user.UserName,
            Email = user.Email
        };

        if (user.Password == null) return BadRequest();
        if (user.Schema == null) return BadRequest();

        var dbNames = await DB.AllDatabaseNamesAsync("localhost");
        var dbExists = dbNames.Any(x => x == user.Schema);
        if (dbExists) return BadRequest();

        var workspaceID = await _databaseRepository.AddDatabase(user.Schema);

        appUser.WorkspaceId = workspaceID;

        IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
        
        return result.Succeeded ? Ok() : Unauthorized();
    }
}