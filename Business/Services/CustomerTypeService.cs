using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class CustomerTypeService(ICustomerTypeRepository customerTypeRepository) : ICustomerTypeService
{
    private readonly ICustomerTypeRepository _customerTypeRepository = customerTypeRepository;

    public async Task<ResponseResult<IEnumerable<CustomerType>>> GetAllCustomerTypesAsync()
    {
        try
        {
            var entities = await _customerTypeRepository.GetAllAsync();
            var types = entities.Select(CustomerTypeFactory.Create);
            return ResponseResult<IEnumerable<CustomerType>>.Ok("",types);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<CustomerType>>.Error("An error occurd when fetching all customer types");
        }
    }
}
