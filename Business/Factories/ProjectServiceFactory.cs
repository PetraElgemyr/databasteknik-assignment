using Business.Models;
using Business.Models.CusomerAddresses;
using Business.Models.ProjectServices;
using Data.Entities;

namespace Business.Factories;

public static class ProjectServiceFactory
{
    public static ProjectServiceWithDetails CreateProjectServiceFromEntity(ProjectServiceEntity entity)
    {
        return new ProjectServiceWithDetails
        {
            EstimatedHours = entity.EstimatedHours,
            ProjectId = entity.ProjectId,
            ServiceId = entity.ServiceId,
            Service = new Service
            {
                Id = entity.Service.Id,
                ServiceType = entity.Service.ServiceTypeName,
                HourlyCost = entity.Service.HourlyCost
            }
        };
    }

    public static ProjectServiceEntity CreateProjectServiceEntityFromRegForm(ProjectServiceRegistrationForm form)
    {
        return new ProjectServiceEntity
        {
            EstimatedHours = form.EstimatedHours,
            ProjectId = form.ProjectId,
            ServiceId = form.ServiceId
        };
       
    }
    
}
