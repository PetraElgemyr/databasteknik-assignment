using Business.Models.CusomerAddresses;
using Business.Models.CustomerContacts;
using Business.Models.Customers;
using Data.Entities;

namespace Business.Factories;

public static class CustomerContactFactory
{

    public static CustomerContact? CreateContactFromEntity(CustomerContactEntity entity) => entity == null ? null : new CustomerContact
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        PhoneNumber = entity.PhoneNumber,
        Customer = new CustomerWithoutType
        {
            Id = entity.Customer.Id,
            CustomerName = entity.Customer.CustomerName,
        }
    };

    public static CustomerAddressCustomerContact? CreateCustomerAddressContactFromEntity(CustomerContactEntity entity) => entity == null ? null : new CustomerAddressCustomerContact
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        PhoneNumber = entity.PhoneNumber,
        CustomerId = entity.Customer.Id,
        CustomerName = entity.Customer.CustomerName
    };
   

}
