using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Models.Customers;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository, ICustomerTypeRepository customerTypeRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly ICustomerTypeRepository _customerTypeRepository = customerTypeRepository;

    public async Task<ResponseResult<Customer?>> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        var customerType = await _customerTypeRepository.GetAsync(ct => ct.Id == form.CustomerTypeId);
        var entity = CustomerFactory.CreateCustomerEntityFromForm(form);

        if (entity == null)
        {
            return ResponseResult<Customer?>.BadRequest("Customer registration form is invalid");
        }
        if (customerType == null)
        {
            return ResponseResult<Customer?>.NotFound("Invalid CustomerType provided!");
        }

        var result = await _customerRepository.AddAsync(entity);
        if (result == null)
        {
            return ResponseResult<Customer?>.Error("Something went wrong when creating the customer.");
        }

        Customer createdEntityWithId = CustomerFactory.CreateCustomerFromEntity(result);
        return ResponseResult<Customer?>.Created("Customer was created successfully!", createdEntityWithId);
    }

    public async Task<ResponseResult<IEnumerable<Customer>>> GetAllCustomersAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        if (entities == null)
        {
            return ResponseResult<IEnumerable<Customer>>.NotFound("No customers found.");
        }

        var customers = entities.Select(CustomerFactory.CreateCustomerFromEntity);


        return ResponseResult<IEnumerable<Customer>>.Ok("Customers found successfully!", customers);
    }

    public async Task<ResponseResult<Customer>> GetOneCustomerByIdAsync(int id)
    {
        var entity = await _customerRepository.GetAsync(c => c.Id == id);
        if (entity == null)
        {
            return ResponseResult<Customer>.NotFound("Customer could not be found.");
        }

        var customer = CustomerFactory.CreateCustomerFromEntity(entity);

        return ResponseResult<Customer>.Ok("Customers found successfully!", customer);
    }

    public async Task<ResponseResult<Customer>> UpdateCustomerAsync(Customer customer)
    {
        var entity = CustomerFactory.CreateCustomerEntityFromCustomer(customer);
        var exists = await _customerRepository.ExistsAsync(c => c.Id == customer.Id);

        if (!exists)
        {
            return ResponseResult<Customer>.NotFound("The provided customer to update could not be found.");
        }

        if (entity == null)
        {
            return ResponseResult<Customer>.BadRequest("The provided customer to update is invalid");
        }

        var updatedEntity = await _customerRepository.UpdateAsync(entity);
        if (updatedEntity == null)
        {
            return ResponseResult<Customer>.Error("Something went wrong when trying to update the customer.");
        }

        var updatedCustomer = CustomerFactory.CreateCustomerFromEntity(updatedEntity);
        return ResponseResult<Customer>.Ok("Customer was successfully updated!", updatedCustomer);
    }

    public async Task<ResponseResult> DeleteOneCustomerAsync(Customer form)
    {
        var entity = CustomerFactory.CreateCustomerEntityFromCustomer(form);

        if (entity == null)
        {
            return ResponseResult<Customer?>.NotFound("The provided customer to delete is invalid");
        }

        var deletedResult = await _customerRepository.RemoveAsync(entity);

        if (!deletedResult)
        {
            return ResponseResult.Failed("Something went wrong when trying to delete the customer.");
        }

        return ResponseResult.NoContentSuccess();
    }

    public async Task<ResponseResult> DeleteCustomerByIdAsync(int id)
    {

        var entity = await _customerRepository.GetAsync(c => c.Id == id);

        if (entity == null)
        {
            return ResponseResult<Customer?>.NotFound("The customer to delete could not be found.");
        }

        var deletedResult = await _customerRepository.RemoveAsync(entity);
        if (!deletedResult)
        {
            return ResponseResult.Failed("Something went wrong when deleting the customer.");
        }

        return ResponseResult.NoContentSuccess();
    }


}
