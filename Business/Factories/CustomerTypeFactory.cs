using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerTypeFactory
{

    public static CustomerType Create(CustomerTypeEntity entity)
    {
        return new CustomerType
        {
            Id = entity.Id,
            CustomerTypeName = entity.CustomerTypeName
        };
    }
}
