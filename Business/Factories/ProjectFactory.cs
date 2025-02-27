using Business.Models;
using Business.Models.Projects;
using Business.Models.Users;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ListProject? CreateListProjectFromEntity(ProjectEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);
            var listProject = new ListProject
            {
                Id = entity.Id,
                ProjectName = entity.ProjectName,
                Description = entity.Description,
                TotalCost = entity.TotalCost,
                CustomerName = entity.Customer.CustomerName,
                StatusTypeName = entity.StatusType.StatusTypeName,
                StartDate = entity.ProjectSchedule.StartDate,
                EndDate = entity.ProjectSchedule.EndDate
            };
            return listProject;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public static Project? CreateProjectFromEntity(ProjectEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            var project = new Project
            {
                Id = entity.Id,
                ProjectName = entity.ProjectName,
                Description = entity.Description,
                TotalCost = entity.TotalCost,
                StatusTypeId = entity.StatusTypeId,
                CustomerId = entity.CustomerId,
                UserId = entity.UserId,
                ProjectScheduleId = entity.ProjectScheduleId,
            };
            return project;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public static ProjectWithDetails? CreateProjectWithDetailsFromEntity(ProjectEntity entity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(entity);

            var project = new ProjectWithDetails
            {
                Id = entity.Id,
                ProjectName = entity.ProjectName,
                Description = entity.Description,
                TotalCost = entity.TotalCost,
                ProjectSchedule = new ProjectSchedule
                {
                    Id = entity.ProjectSchedule.Id,
                    StartDate = entity.ProjectSchedule.StartDate,
                    EndDate = entity.ProjectSchedule.EndDate
                },
                Customer = CustomerFactory.CreateCustomerFromEntity(entity.Customer)!,
                StatusType = StatusTypeFactory.Create(entity.StatusType)!,
                User = UserFactory.CreateUserFromEntity(entity.User)!
            };
            return project;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }


    }

    public static ProjectEntity? CreateEntityFromRegistrationForm(ProjectRegistrationForm form, ProjectScheduleEntity scheduleEntity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(scheduleEntity);

            var projectEntity = new ProjectEntity
            {
                ProjectName = form.ProjectName,
                Description = form.Description,
                TotalCost = form.TotalCost,
                CustomerId = form.CustomerId,
                StatusTypeId = form.StatusTypeId,
                UserId = form.UserId,
                ProjectScheduleId = scheduleEntity.Id,
            };
            return projectEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public static ProjectEntity? CreateEntityFromUpdateForm(ProjectUpdateForm form, ProjectScheduleEntity scheduleEntity)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(scheduleEntity);

            var projectEntity = new ProjectEntity
            {
                Id = form.Id,
                ProjectName = form.ProjectName,
                Description = form.Description,
                TotalCost = form.TotalCost,
                CustomerId = form.CustomerId,
                StatusTypeId = form.StatusTypeId,
                UserId = form.UserId,
                ProjectScheduleId = scheduleEntity.Id,
            };

            return projectEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}



