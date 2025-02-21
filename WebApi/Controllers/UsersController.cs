using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;


    [HttpGet]
    public async Task<IActionResult> GetUsersForList()
    {
        var result = await _userService.GetAllUsersForListAsync();

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpGet]
    [Route("projectmanagers")]
    public async Task<IActionResult> GetAllProjectManagers()
    {
        var entities = await _userService.GetAllProjectManagersAsync();
        return Ok(entities);
    }


    [HttpPost]
    public async Task<IActionResult> CreateNewUser(UserRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _userService.CreateUserAsync(form);
        return result.StatusCode switch
        {
            201 => Created("", result.Result),
            400 => BadRequest(result.Message),
            409 => Conflict(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserUpdateForm form)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _userService.UpdateUserAsync(form);
        return result.StatusCode switch
        {
            201 => Created("", result.Result),
            400 => BadRequest(result.Message),
            409 => Conflict(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        var result = await _userService.DeleteUserByIdAsync(id);

        return result.StatusCode switch
        {

            204 => NoContent(), // lyckad borttaning kod 204, ist för 200
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteUser(UserUpdateForm form)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _userService.DeleteUserAsync(form);

        return result.StatusCode switch
        {

            204 => NoContent(), // lyckad borttaning kod 204, ist för 200
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

}
