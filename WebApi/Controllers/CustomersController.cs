using Business.Interfaces;
using Business.Models.Customers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(ICustomerService customerService) : ControllerBase
{

    private readonly ICustomerService _customerService = customerService;

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await _customerService.GetAllCustomersAsync();
        
        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneCustomerById(int id)
    {
        var result = await _customerService.GetOneCustomerByIdAsync(id);

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpPost]
    public async Task<IActionResult> CreateOneCustomer(CustomerRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid customer provided.");
        }

        var result = await _customerService.CreateCustomerAsync(form);

        return result.StatusCode switch
        {
            201 => Created("",result.Result),
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            409 => Conflict(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOneCustomer(Customer updateForm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid customer to update provided.");
        }
        var result = await _customerService.UpdateCustomerAsync(updateForm);

        return result.StatusCode switch
        {
            200 => Ok(result.Result),
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            409 => Conflict(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerById(int id)
    {
        var result = await _customerService.DeleteCustomerByIdAsync(id);

        return result.StatusCode switch
        {
            204 => NoContent(),
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOneCustomer(Customer customerToDelete)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid customer to delete provided.");
        }
        var result = await _customerService.DeleteOneCustomerAsync(customerToDelete);

        return result.StatusCode switch
        {
            204 => NoContent(),
            400 => BadRequest(result.Message),
            404 => NotFound(result.Message),
            _ => Problem(result.Message),
        };
    }
}
