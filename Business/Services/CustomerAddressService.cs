using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.CusomerAddresses;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerAddressService(ICustomerAddressRepository customerAddressRepository) : ICustomerAddressService
{
    private readonly ICustomerAddressRepository _customerAddressRepository = customerAddressRepository;

    public async Task<ResponseResult<IEnumerable<CustomerAddress>>> GetAllCustomerAddressesAsync()
    {
        var entities = await _customerAddressRepository.GetAllAsync();
        if (entities == null)
        {
            return ResponseResult<IEnumerable<CustomerAddress>>.NotFound("No customer addresses found");
        }

        IEnumerable<CustomerAddress> customerAddresses = entities.Select(CustomerAddressFactory.CreateCustomerAddressesFromEntity);
        return ResponseResult<IEnumerable<CustomerAddress>>.Ok("Customer addresses found", customerAddresses);
    }

    public async Task<ResponseResult<CustomerAddressWithDetails?>> GetOneCustomerAddressWithDetailsByIdAsync(int id)
    {
        var entity = await _customerAddressRepository.GetAsync(x => x.Id == id);
        if (entity == null)
        {
            return ResponseResult<CustomerAddressWithDetails?>.NotFound("The customer address could not be found");
        }

        var customerAddressWithDetails = CustomerAddressFactory.CreateCustomerAddressWithDetailsFromEntity(entity);

        return ResponseResult<CustomerAddressWithDetails?>.Ok("Customer was found", customerAddressWithDetails);
    }
}
