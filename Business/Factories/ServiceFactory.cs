using Business.Models;
using Business.Models.CusomerAddresses;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{

    public static Service CreateServiceFromEntity(ServiceEntity entity)
    {
        return new Service
        {
            Id = entity.Id,
            ServiceType = entity.ServiceTypeName,
            HourlyCost = entity.HourlyCost
        };
    }

}
