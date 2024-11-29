using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NinetySix.Server.Models.Entities.Auth;
using NinetySix.Server.Models.Entities.Common.Identity;
using NinetySix.Server.Models.Repositories;

namespace NinetySix.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ManageRoleController : ControllerBase
{
    private readonly RoleManager<Role> _roleManager;

    public ManageRoleController(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Role role)
    {
       
            if(role.Name is  null) return BadRequest();
            
            
            IdentityResult result = await _roleManager.CreateAsync(role);
            
            return result.Succeeded ? Ok() : Unauthorized();
    }
}