using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class RoleRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllRoles()
    {
        var context = DataContextSeeder.GetDataContext();
        context.Roles.AddRange(TestData.RoleEntities);
        await context.SaveChangesAsync();

        var roleRepository = new RoleRepository(context);

        var result = await roleRepository.GetAllAsync();

        Assert.Equal(TestData.RoleEntities.Length, result.Count());
    }
}

