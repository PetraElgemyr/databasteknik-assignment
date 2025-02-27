using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerTypeFactory
{
    public static CustomerType? CreateCustomerTypeFromEntity(CustomerTypeEntity entity) => entity == null ? null : new CustomerType
    {
        Id = entity.Id,
        CustomerTypeName = entity.CustomerTypeName
    };

    public static CustomerTypeEntity? CreateEntityFromCustomer(CustomerType customerType) => customerType == null ? null : new CustomerTypeEntity
    {
        Id = customerType.Id,
        CustomerTypeName = customerType.CustomerTypeName
    };

}
