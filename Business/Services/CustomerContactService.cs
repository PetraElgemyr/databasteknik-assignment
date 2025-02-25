using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.CustomerContacts;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class CustomerContactService(ICustomerContactRepoitory customerContactRepository) : ICustomerContactService
{
    private readonly ICustomerContactRepoitory _customerContactRepository = customerContactRepository;

    public async Task<ResponseResult<IEnumerable<CustomerContact>>> GetAllCustomerContactsByCustomerIdAsync(int customerId)
    {
        try
        {
            var entities = await _customerContactRepository.GetAllCustomerContactsByCustomerId(customerId);
            var customerContacts = entities.Select(CustomerContactFactory.CreateContactFromEntity);

            return ResponseResult<IEnumerable<CustomerContact>>.Ok("All contacts for the current customer", customerContacts);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<CustomerContact>>.Error($"An error occured when trying to fetch customer contacts with customerId {customerId}");
        }
    }
}
