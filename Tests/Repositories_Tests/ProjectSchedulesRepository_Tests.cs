using Data.Entities;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class ProjectSchedulesRepository_Tests
{

    [Fact]
    public async Task GetAllAsync_ShouldReturnProjectSchedules()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);
        await context.SaveChangesAsync();

        var projectScheduleRepository = new ProjectScheduleRepository(context);
        var result = await projectScheduleRepository.GetAllAsync();

        Assert.Equal(TestData.ProjectScheduleEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnOneProjectSchedule()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);
        await context.SaveChangesAsync();

        var projectScheduleRepository = new ProjectScheduleRepository(context);
        var result = await projectScheduleRepository.GetAsync(x => x.Id == 1);

        Assert.NotNull(result);
    }


    [Fact]
    public async Task AddAsync_ShouldReturnAddedProjectSchedule()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ChangeTracker.Clear();

        var projectSchedule = new ProjectScheduleEntity
        {
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(30),
        };
        var projectScheduleRepository = new ProjectScheduleRepository(context);
        var result = await projectScheduleRepository.AddAsync(projectSchedule);

        Assert.NotNull(result);
        Assert.Equal(projectSchedule.StartDate, result.StartDate);
    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnProjectScheduleExistsTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);
        await context.SaveChangesAsync();

        var projectScheduleRepository = new ProjectScheduleRepository(context);

        var result = await projectScheduleRepository.ExistsAsync(s => s.Id == 1);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldÚpdateAndReturnProjectSchedule()
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
    public async Task RemoveAsync_ShouldRemoveProjectScheduleAndReturnTrue()
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

