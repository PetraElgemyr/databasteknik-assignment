using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerAddressesController(ICustomerAddressService customerAddressService) : ControllerBase
{

    private readonly ICustomerAddressService _customerAddressService = customerAddressService;

    [HttpGet]
    public async Task<IActionResult> GetAllCustomerAddresses()
    {
        var result = await _customerAddressService.GetAllCustomerAddressesAsync();
      
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneCustomerAddressWithDetails(int id)
    {
        var result = await _customerAddressService.GetOneCustomerAddressWithDetailsByIdAsync(id);

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }
}
