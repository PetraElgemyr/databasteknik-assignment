using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class StatusTypeRepository_Tests
{


    [Fact]
    public async Task GetAllAsync_ShouldReturnAllStatusTypes()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        await context.SaveChangesAsync();

        var statusTypeRepository = new StatusTypeRepository(context);

        var result = await statusTypeRepository.GetAllAsync();
        Assert.Equal(TestData.StatusTypeEntities.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnOneStatusType()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        await context.SaveChangesAsync();

        var statusTypeRepository = new StatusTypeRepository(context);
        var result = await statusTypeRepository.GetAsync(x => x.Id == 1);

        Assert.NotNull(result);
    }


    [Fact]
    public async Task AddAsync_ShouldReturnAddedStatusType()
    {
        var context = new DataContextSeeder().GetDataContext();

        var statusTypeToAdd = new StatusTypeEntity { StatusTypeName = "Pågående" };

        var statusTypeRepository = new StatusTypeRepository(context);
        var result = await statusTypeRepository.AddAsync(statusTypeToAdd);

        Assert.NotNull(result);
        Assert.Equal("Pågående", result.StatusTypeName);

    }


    [Fact]
    public async Task ExistsAsync_ShouldReturnCustomerTypeExistsTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        await context.SaveChangesAsync();

        var statusTypeRepository = new StatusTypeRepository(context);

        var result = await statusTypeRepository.ExistsAsync(st => st.Id == 1);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldÚpdateAndReturnStatusType()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var statusTypeRepository = new StatusTypeRepository(context);
        var statusTypeToUpdate = new StatusTypeEntity { Id = 3, StatusTypeName = "Klar" };

        var result = await statusTypeRepository.UpdateAsync(statusTypeToUpdate);

        Assert.NotNull(result);
        Assert.Equal(statusTypeToUpdate.StatusTypeName, result.StatusTypeName);
    }

    [Fact]
    public async Task RemoveAsync_ShouldRemoveStatusTypeAndReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.StatusTypes.AddRange(TestData.StatusTypeEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var statusTypeRepository = new StatusTypeRepository(context);
        var typeToDelete = await statusTypeRepository.GetAsync(x => x.Id == 1);

        var result = await statusTypeRepository.RemoveAsync(typeToDelete!);

        Assert.True(result);
    }

}

