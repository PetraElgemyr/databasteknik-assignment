using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class CustomerTypeService(ICustomerTypeRepository customerTypeRepository) : ICustomerTypeService
{
    private readonly ICustomerTypeRepository _customerTypeRepository = customerTypeRepository;

    public async Task<IEnumerable<CustomerType>> GetAllCustomerTypesAsync()
    {
        var entities = await _customerTypeRepository.GetAllAsync();
        var types = entities.Select(CustomerTypeFactory.Create);
        return types;
    }

}
