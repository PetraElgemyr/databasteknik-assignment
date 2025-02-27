using Business.Models;
using Business.Models.CusomerAddresses;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{

    public static Service? CreateServiceFromEntity(ServiceEntity entity) => entity == null ? null : new Service
    {
        Id = entity.Id,
        ServiceType = entity.ServiceTypeName,
        ServiceName = entity.ServiceName,
        HourlyCost = entity.HourlyCost
    };


    public static ServiceEntity? CreateServiceEntityFromForm(ServiceRegistration form) => form == null ? null : new ServiceEntity
    {
        ServiceTypeName = form.ServiceType,
        ServiceName = form.ServiceName,
        HourlyCost = form.HourlyCost
    };

}
