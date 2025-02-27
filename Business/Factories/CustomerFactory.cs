using Business.Models;
using Business.Models.Customers;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity? CreateCustomerEntityFromForm(CustomerRegistrationForm form) => form == null ? null : new CustomerEntity
    {
        CustomerName = form.CustomerName,
        CustomerTypeId = form.CustomerTypeId
    };


    public static Customer? CreateCustomerFromEntity(CustomerEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);
            var customer = new Customer
            {
                Id = entity.Id,
                CustomerName = entity.CustomerName,
                CustomerType = CustomerTypeFactory.CreateCustomerTypeFromEntity(entity.CustomerType)!
            };

            return customer;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public static CustomerEntity? CreateCustomerEntityFromCustomer(Customer customer)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(customer);
            var customerEntity = new CustomerEntity
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerTypeId = customer.CustomerType.Id,
                CustomerType = CustomerTypeFactory.CreateEntityFromCustomer(customer.CustomerType)!

            };
            return customerEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public static CustomerEntity? CreateCustomerEntityFromUpdateForm(CustomerUpdateForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);
            var entity = new CustomerEntity
            {
                Id = form.Id,
                CustomerName = form.CustomerName,
                CustomerTypeId = form.CustomerType.Id,
                CustomerType = CustomerTypeFactory.CreateEntityFromCustomer(form.CustomerType)!
               
            }; 
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }


    }

}
