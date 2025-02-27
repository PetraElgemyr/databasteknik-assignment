using Business.Models;
using Business.Models.CusomerAddresses;
using Business.Models.CustomerContacts;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class CustomerAddressFactory
{

    public static CustomerAddress? CreateCustomerAddressesFromEntity(CustomerAddressEntity entity) => entity == null ? null : new CustomerAddress
    {
        Id = entity.Id,
        StreetName = entity.StreetName,
        StreetNumber = entity.StreetNumber,
        PostalCodeId = entity.PostalCodeId,
        CustomerContactId = entity.CustomerContactId,
    };


    public static CustomerAddressWithDetails? CreateCustomerAddressWithDetailsFromEntity(CustomerAddressEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            var customerAddress =  new CustomerAddressWithDetails
            {
                Id = entity.Id,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber,
                PostalCode = PostalCodeFactory.CreateRegistrationFormFromEntity(entity.PostalCode)!,
                CustomerContact = CustomerContactFactory.CreateCustomerAddressContactFromEntity(entity.CustomerContact)!
            };
            return customerAddress;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}


