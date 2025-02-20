using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostalCodesController(IPostalCodeService postalCodeService) : ControllerBase
{

    private readonly IPostalCodeService _postalCodeService = postalCodeService;

    [HttpPost]
    public async Task<IActionResult> CreateNewPostalCode(PostalCodeRegistrationForm postalCodeForm)
    {
        var result = await _postalCodeService.CreatePostalCodeAsync(postalCodeForm);

        return result.StatusCode switch
        {
            201 => Created("", null),
            400 => BadRequest(result.Message),
            409 => Conflict(result.Message),
            _ => Problem(result.Message),
        };
    }
}
