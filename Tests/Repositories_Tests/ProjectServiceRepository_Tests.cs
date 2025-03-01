using Data.Entities;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class ProjectServiceRepository_Tests
{


    [Fact]
    public async Task GetAllProjectServicesByProjectIdAsync_ShouldReturnProjectServicesByProjectId()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        context.Services.AddRange(TestData.ServiceEntities);

        await context.SaveChangesAsync();

        var projectServiceRepository = new ProjectServiceRepository(context);
        var rest = await projectServiceRepository.GetAllAsync();

        var result = await projectServiceRepository.GetAllProjectServicesByProjectIdAsync(TestData.ProjectEntities[0].Id);

        Assert.NotNull(result);
        Assert.Equal(rest.Count(), result.Count());
    }




    [Fact]
    public async Task RemoveAllProjectServicesByProjectId_ShouldReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        await context.SaveChangesAsync();

        var projectServiceRepository = new ProjectServiceRepository(context);

        var result = await projectServiceRepository.RemoveAllProjectServicesByProjectId(1);

        Assert.True(result);
    }

    [Fact]
    public async Task RemoveAsyncByFKKeys_ShouldReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        await context.SaveChangesAsync();

        var projectServiceRepository = new ProjectServiceRepository(context);

        var result = await projectServiceRepository.RemoveAsyncByFKKeys(1, 1);

        Assert.True(result);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnProjectServices()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        await context.SaveChangesAsync();

        var projectServiceRepository = new ProjectServiceRepository(context);

        var result = await projectServiceRepository.GetAllAsync();

        Assert.Equal(TestData.ProjectServiceEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnOneProjectService()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        await context.SaveChangesAsync();

        var projectServiceRepository = new ProjectServiceRepository(context);
        var result = await projectServiceRepository.GetAsync(x => x.ProjectId == 1 && x.ServiceId == 1);

        Assert.NotNull(result);
    }


    [Fact]
    public async Task AddAsync_ShouldReturnAddedProjectService()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ChangeTracker.Clear();

        var projectService = new ProjectServiceEntity
        {
            ProjectId = 1,
            ServiceId = 1,
            EstimatedHours = 100
        };
        var projectServiceRepository = new ProjectServiceRepository(context);
        var result = await projectServiceRepository.AddAsync(projectService);

        Assert.NotNull(result);
        Assert.Equal(100, result.EstimatedHours);
    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnProjectServiceExistsTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        await context.SaveChangesAsync();

        var projectServiceRepository = new ProjectServiceRepository(context);

        var result = await projectServiceRepository.ExistsAsync(r => r.ProjectId == 1 && r.ServiceId == 1);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldÚpdateAndReturnProjectService()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();

        var projectServiceRepository = new ProjectServiceRepository(context);
        var projectService = new ProjectServiceEntity
        {
            ProjectId = 1,
            ServiceId = 1,
            EstimatedHours = 111
        };


        var result = await projectServiceRepository.UpdateAsync(projectService);

        Assert.NotNull(result);
        Assert.Equal(projectService.EstimatedHours, result.EstimatedHours);
    }

    [Fact]
    public async Task RemoveAsync_ShouldRemoveProjectServiceAndReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectServices.AddRange(TestData.ProjectServiceEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var projectServiceRepository = new ProjectServiceRepository(context);
        var roleToDelete = await projectServiceRepository.GetAsync(x => x.ProjectId == 1 && x.ServiceId == 1);

        var result = await projectServiceRepository.RemoveAsync(roleToDelete!);

        Assert.True(result);
    }



}

