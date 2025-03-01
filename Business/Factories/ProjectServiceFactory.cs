using Business.Models;
using Business.Models.CusomerAddresses;
using Business.Models.ProjectServices;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class ProjectServiceFactory
{
    public static ProjectServiceWithDetails? CreateProjectServiceFromEntity(ProjectServiceEntity entity)
    {
        try
        {
            var projectService = new ProjectServiceWithDetails
            {
                EstimatedHours = entity.EstimatedHours,
                ProjectId = entity.ProjectId,
                ServiceId = entity.ServiceId,
                Service = ServiceFactory.CreateServiceFromEntity(entity.Service)!
            };
            return projectService;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public static ProjectServiceEntity? CreateProjectServiceEntityFromRegForm(ProjectServiceRegistrationForm form) => form == null ? null : new ProjectServiceEntity
    {
        EstimatedHours = form.EstimatedHours,
        ProjectId = form.ProjectId,
        ServiceId = form.ServiceId
    };

    public static ProjectServiceEntity? CreateEntityFromNewProjectForm(ProjectServiceRegistrationFromNewProject form, int projectId)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var entity = new ProjectServiceEntity
            {
                EstimatedHours = form.EstimatedHours,
                ProjectId = projectId,
                ServiceId = form.ServiceId
            };
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
   
}

