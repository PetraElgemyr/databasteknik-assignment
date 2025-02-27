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
            ServiceName = entity.ServiceName,
            HourlyCost = entity.HourlyCost
        };
    }

    public static ServiceEntity CreateServiceEntityFromForm(ServiceRegistration form)
    {
        return new ServiceEntity
        {
            ServiceTypeName = form.ServiceType,
            ServiceName = form.ServiceName,
            HourlyCost = form.HourlyCost
        };
    }

}
