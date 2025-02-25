using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerContactsController(ICustomerContactService customerContactService) : ControllerBase
{
    private readonly ICustomerContactService _customerContactService = customerContactService;

    [HttpGet("customer/{id}")]
    public async Task<IActionResult> GetCustomerContactsByCustomerId(int id)
    {
        var result = await _customerContactService.GetAllCustomerContactsByCustomerIdAsync(id);

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            _ => Problem(result.Message),
        };
    }
}
