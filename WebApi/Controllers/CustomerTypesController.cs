using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypesController(ICustomerTypeService customerTypeService) : ControllerBase
    {

        private readonly ICustomerTypeService _customerTypeService = customerTypeService;

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerTypes()
        {
            var result = await _customerTypeService.GetAllCustomerTypesAsync();
            return result.StatusCode switch
            {
                200 => Ok(result.Result),
                _ => Problem(result.Message),
            };
        }
    }
}
