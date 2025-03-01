using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class RoleRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllRoles()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();

        var roleRepository = new RoleRepository(context);

        var result = await roleRepository.GetAllAsync();

        Assert.Equal(TestData.RoleEntities.Length, result.Count());
    }


    [Fact]
    public async Task GetAsync_ShouldReturnOneRole()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();

        var roleRepository = new RoleRepository(context);
        var result = await roleRepository.GetAsync(x => x.Id == 1);

        Assert.NotNull(result);
    }


    [Fact]
    public async Task AddAsync_ShouldReturnAddedRole()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ChangeTracker.Clear();

        var roleToAdd = new RoleEntity { Id = 1, RoleName = "Projektledare" };
        var roleRepository = new RoleRepository(context);
        var result = await roleRepository.AddAsync(roleToAdd);

        Assert.NotNull(result);
        Assert.Equal("Projektledare", result.RoleName);
    }


    [Fact]
    public async Task ExistsAsync_ShouldReturnRoleExistsTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();

        var roleRepository = new RoleRepository(context);

        var result = await roleRepository.ExistsAsync(r => r.Id == 1);

        Assert.True(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldÚpdateAndReturnRole()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();

        var roleRepository = new RoleRepository(context);
        var roleToAdd = new RoleEntity { Id = 1, RoleName = "Projektledare" };


        var result = await roleRepository.UpdateAsync(roleToAdd);

        Assert.NotNull(result);
        Assert.Equal(roleToAdd.RoleName, result.RoleName);
    }

    [Fact]
    public async Task RemoveAsync_ShouldRemoveServiceAndReturnTrue()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        var roleRepository = new RoleRepository(context);
        var roleToDelete = await roleRepository.GetAsync(x => x.Id == 1);

        var result = await roleRepository.RemoveAsync(roleToDelete!);

        Assert.True(result);
    }

}

