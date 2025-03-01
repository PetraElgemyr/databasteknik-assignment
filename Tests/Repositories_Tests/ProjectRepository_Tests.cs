using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class ProjectRepository_Tests
{

   
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjects()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Projects.AddRange(TestData.ProjectEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);

        await context.SaveChangesAsync();

        var projectRepository = new ProjectRepository(context);

        var result = await projectRepository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(TestData.ProjectEntities.Length, result.Count());
    }

    [Fact] 
    public async Task GetAsync_ShouldReturnOneProject()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Projects.AddRange(TestData.ProjectEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);
        context.Users.AddRange(TestData.UserEntities);
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();


        var projectRepository = new ProjectRepository(context);

        var result = await projectRepository.GetAsync(x => x.Id == TestData.ProjectEntities[0].Id);

        Assert.NotNull(result);
        Assert.Equal(TestData.ProjectEntities[0].CustomerId, result.CustomerId);
    }


    [Fact]
    public async Task GetAllProjectByCustomerIdAsync_ShouldReturnProjectsByASpecificCustomerId()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Projects.AddRange(TestData.ProjectEntities);
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);
        context.Customers.AddRange(TestData.CustomerEntities);
        await context.SaveChangesAsync();

        var projectRepository = new ProjectRepository(context);

        var result = await projectRepository.GetAllProjectByCustomerIdAsync(TestData.CustomerEntities[0].Id);

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task AddAsync_ShouldAddAndReturnCreatedProject()
    {
        var context = new DataContextSeeder().GetDataContext();

        var projectToAdd = new ProjectEntity
        {
            ProjectName = "Projekt 1",
            Description = "Beskrivning av projekt 1",
            TotalCost = 10000000,
            CustomerId = 1,
            StatusTypeId = 1,
            UserId = 1,
            ProjectScheduleId = 1
        };

        var projectRepository = new ProjectRepository(context);

        var result = await projectRepository.AddAsync(projectToAdd);
        Assert.NotNull(result);
        Assert.Equal(projectToAdd.ProjectName, result.ProjectName);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateAndReturnUpdatedProject()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Projects.AddRange(TestData.ProjectEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();
        var projectToUpdate = new ProjectEntity
        {
            Id = 1,
            ProjectName = "NYTT NAMN",
            Description = "Ny beskrivning",
            TotalCost = 10000000,
            CustomerId = 1,
            StatusTypeId = 1,
            UserId = 1,
            ProjectScheduleId = 1
        };

        var projectRepository = new ProjectRepository(context);

        var result = await projectRepository.UpdateAsync(projectToUpdate);
        Assert.NotNull(result);
        Assert.Equal(projectToUpdate.ProjectName, result.ProjectName);
    }

    [Fact]
    public async Task RemoveAsync_ShouldRemoveProjectAndReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Projects.AddRange(TestData.ProjectEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();
        var projectToDelete =  new ProjectEntity
        {
            Id = 1,
            ProjectName = "Projekt 1",
            Description = "Beskrivning av projekt 1",
            TotalCost = 10000000,
            CustomerId =1,
            StatusTypeId = 1,
            UserId = 1,
            ProjectScheduleId = 1
        };

        var projectRepository = new ProjectRepository(context);

        var result = await projectRepository.RemoveAsync(projectToDelete);
        Assert.True(result);
    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnTrueIfProjectExists()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Projects.AddRange(TestData.ProjectEntities);
        await context.SaveChangesAsync();

        var projectRepository = new ProjectRepository(context);
        var result =await  projectRepository.ExistsAsync(x => x.Id == 1);

        Assert.True(result);

    }
}

