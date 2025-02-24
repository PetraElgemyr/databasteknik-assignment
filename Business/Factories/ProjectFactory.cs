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
                RoleId = entity.User.RoleId
            }
        };
    }

    public static ProjectEntity CreateEntityFromRegistrationForm(ProjectRegistrationForm form)
    {
        return new ProjectEntity
        {
            ProjectName = form.ProjectName,
            Description = form.Description,
            TotalCost = form.TotalCost,
            CustomerId = form.CustomerId,
            StatusTypeId = form.StatusTypeId,
            UserId = form.UserId
        };
    }

    public static ProjectEntity CreateEntityFromUpdateForm(ProjectUpdateForm form)
    {

        return new ProjectEntity
        {
            Id = form.Id,
            ProjectName = form.ProjectName,
            Description = form.Description,
            TotalCost = form.TotalCost,
            CustomerId = form.Customer.Id,
            Customer = new CustomerEntity
            {
                Id = form.Customer.Id,
                CustomerName = form.Customer.CustomerName,
                CustomerTypeId = form.Customer.CustomerType.Id,
                CustomerType = new CustomerTypeEntity { 
                    Id = form.Customer.CustomerType.Id,
                    CustomerTypeName = form.Customer.CustomerType.CustomerTypeName
                },
            },
            StatusTypeId = form.StatusType.Id,
            StatusType = new StatusTypeEntity { 
            Id = form.StatusType.Id,
            StatusTypeName = form.StatusType.StatusName
            },
            UserId = form.User.Id,
            User = new UserEntity
            {
                Id = form.User.Id,
                FirstName = form.User.FirstName,
                LastName = form.User.LastName,
                Email = form.User.Email,
                PhoneNumber = form.User.PhoneNumber,
                RoleId = form.User.RoleId
            }
        };
    }
}



