using Business.Models;
using Business.Models.CusomerAddresses;
using Business.Models.Customers;
using Business.Models.Projects;
using Business.Models.Users;
using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ListProject CreateListProjectFromEntity(ProjectEntity entity)
    {
        return new ListProject
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
    }

    public static Project CreateProjectFromEntity(ProjectEntity entity)
    {
        return new Project
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
    }

    public static ProjectWithDetails CreateProjectWithDetailsFromEntity(ProjectEntity entity)
    {
        return new ProjectWithDetails
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
            Customer = new Customer
            {
                Id = entity.Customer.Id,
                CustomerName = entity.Customer.CustomerName,
                CustomerType = new CustomerType
                {
                    Id = entity.Customer.CustomerType.Id,
                    CustomerTypeName = entity.Customer.CustomerType.CustomerTypeName,
                }
            },
            StatusType = new StatusType
            {
                Id = entity.StatusType.Id,
                StatusName = entity.StatusType.StatusTypeName
            },
            User = new User
            {
                Id = entity.User.Id,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName,
                Email = entity.User.Email,
                PhoneNumber = entity.User.PhoneNumber,
                RoleId = entity.User.Role.Id
            }
        };
    }

    public static ProjectEntity CreateEntityFromRegistrationForm(ProjectRegistrationForm form, ProjectScheduleEntity scheduleEntity)
    {
        return new ProjectEntity
        {
            ProjectName = form.ProjectName,
            Description = form.Description,
            TotalCost = form.TotalCost,
            CustomerId = form.CustomerId,
            StatusTypeId = form.StatusTypeId,
            UserId = form.UserId,
            ProjectScheduleId = scheduleEntity.Id,
        };
    }

    public static ProjectEntity CreateEntityFromUpdateForm(ProjectUpdateForm form, ProjectScheduleEntity scheduleEntity)
    {
        return new ProjectEntity
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
    }


}



