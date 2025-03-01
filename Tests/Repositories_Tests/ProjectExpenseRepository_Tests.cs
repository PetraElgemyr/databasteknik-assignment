using Data.Repositories;
using Tests.SeedData;

namespace Tests.Repositories_Tests;

public class ProjectExpenseRepository_Tests
{


    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjectExpenses()
    {
        var context = new DataContextSeeder().GetDataContext();
        context.ProjectExpenses.AddRange(TestData.ProjectExpenses);
        await context.SaveChangesAsync();

        var projectExpenseRepository = new ProjectExpenseRepository(context);

        var result = await projectExpenseRepository.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(TestData.ProjectLogs.Length, result.Count());
    }
}

