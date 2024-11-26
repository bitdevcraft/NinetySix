using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NinetySix.Server.Models.Entities.Common.Identity;

namespace NinetySix.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public AuthController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Create(RegisterUser user)
    {
     
            User appUser = new User
            {
                UserName = user.UserName,
                Email = user.Email
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
            // if (result.Succeeded)
            //     ViewBag.Message = "User Created Successfully";
            // else
            // {
            //     foreach (IdentityError error in result.Errors)
            //         ModelState.AddModelError("", error.Description);
            // }

            return result.Succeeded ? Ok() : Unauthorized();

    }
}