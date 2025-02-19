using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    
    [HttpGet]
    public async Task<IActionResult> GetAllProjectManagers()
    {
        var entities = await _userService.GetAllProjectManagersAsync();
        return Ok(entities);
    }
}
