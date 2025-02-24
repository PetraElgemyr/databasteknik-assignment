using Business.Models;
using Business.Models.CusomerAddresses;
using Business.Models.CustomerContacts;
using Data.Entities;

namespace Business.Factories;

public static class CustomerAddressFactory
{

    public static CustomerAddress CreateCustomerAddressesFromEntity(CustomerAddressEntity entity)
    {
        return new CustomerAddress
        {
            Id = entity.Id,
            StreetName = entity.StreetName,
            StreetNumber = entity.StreetNumber,
            PostalCodeId = entity.PostalCodeId,
            CustomerContactId = entity.CustomerContactId,
        };
    }

    public static CustomerAddressWithDetails CreateCustomerAddressWithDetailsFromEntity(CustomerAddressEntity entity)
    {
        return new CustomerAddressWithDetails
        {
            Id = entity.Id,
            StreetName = entity.StreetName,
            StreetNumber = entity.StreetNumber,
            PostalCode =new PostalCodeRegistrationForm
            {
                PostalCodeNumber = entity.PostalCode.PostalCode, 
                City = entity.PostalCode.City
            } ,
            CustomerContact = new CustomerAddressCustomerContact
            {
                Id = entity.CustomerContactId,
                FirstName = entity.CustomerContact.FirstName,
                LastName = entity.CustomerContact.LastName,
                Email = entity.CustomerContact.Email,
                PhoneNumber = entity.CustomerContact.PhoneNumber,
                CustomerId = entity.CustomerContact.Customer.Id,
                CustomerName = entity.CustomerContact.Customer.CustomerName
            }
        };
    }
}

