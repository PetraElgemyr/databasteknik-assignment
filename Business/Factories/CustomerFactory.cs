﻿using Business.Models;
using Business.Models.Customers;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity CreateCustomerEntityFromForm(CustomerRegistrationForm form)
    {
        return new CustomerEntity
        {
            CustomerName = form.CustomerName,
            CustomerTypeId = form.CustomerTypeId
        };
    }

    public static Customer CreateCustomerFromEntity(CustomerEntity entity)
    {
        return new Customer
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            //CustomerTypeId = entity.CustomerType.Id,
            CustomerType = new CustomerType
            {
                Id = entity.CustomerType.Id,
                CustomerTypeName = entity.CustomerType.CustomerTypeName,
            }
        };
    }

    public static CustomerEntity CreateCustomerEntityFromCustomer(Customer customer)
    {
        return new CustomerEntity
        {
            Id = customer.Id,
            CustomerName = customer.CustomerName,
            CustomerTypeId = customer.CustomerType.Id,
            CustomerType = new CustomerTypeEntity
            {
                Id = customer.CustomerType.Id,
                CustomerTypeName = customer.CustomerType.CustomerTypeName
            }
        };
    }

    public static CustomerEntity CreateCustomerEntityFromUpdateForm(CustomerUpdateForm form)
    {
        return new CustomerEntity
        {
            Id = form.Id,
            CustomerName = form.CustomerName,
            CustomerTypeId = form.CustomerType.Id,
            CustomerType = new CustomerTypeEntity
            {
                Id = form.CustomerType.Id,
                CustomerTypeName = form.CustomerType.CustomerTypeName
            }
        };
    }

}
