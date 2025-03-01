using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Tests.SeedData;

public class DataContextSeeder
{

    public DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    //public static async Task SeedAsync(DataContext context)
    //{
    //    context.Roles.AddRange(Hass.RoleEntities);
    //    context.Users.AddRange(TestData.UserEntities);
    //    context.StatusTypes.AddRange(TestData.StatusTypeEntities);
    //    context.PostalCodes.AddRange(TestData.PostalCodeEntities);

    //    context.Customers.AddRange(TestData.CustomerEntities);
    //    context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
    //    context.CustomerAddresses.AddRange(TestData.CustomerAddressEntities);
    //    context.CustomerContacts.AddRange(TestData.CustomerContactEntities);

    //    context.Services.AddRange(TestData.ServiceEntities);
    //    context.ProjectServices.AddRange(TestData.ProjectServiceEntities);

    //    context.ProjectLogs.AddRange(TestData.ProjectLogEntities);
    //    context.ProjectDocuments.AddRange(TestData.ProjectDocumentEntities);
    //    context.ProjectExpenses.AddRange(TestData.ProjectExpenseEntities);
    //    context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);
    //    context.Projects.AddRange(TestData.ProjectEntities);

    //    await context.SaveChangesAsync();
    //}

    //public static async Task SeedAsync(DataContext context)
    //{
    //    context.Roles.AddRange(TestData.RoleEntities);
    //    context.Users.AddRange(TestData.UserEntities);
    //    context.StatusTypes.AddRange(TestData.StatusTypeEntities);
    //    context.PostalCodes.AddRange(TestData.PostalCodeEntities);

    //    context.Customers.AddRange(TestData.CustomerEntities);
    //    context.CustomerTypes.AddRange(TestData.CustomerTypeEntities);
    //    context.CustomerAddresses.AddRange(TestData.CustomerAddressEntities);
    //    context.CustomerContacts.AddRange(TestData.CustomerContactEntities);

    //    context.Services.AddRange(TestData.ServiceEntities);
    //    context.ProjectServices.AddRange(TestData.ProjectServiceEntities);

    //    context.ProjectLogs.AddRange(TestData.ProjectLogEntities);
    //    context.ProjectDocuments.AddRange(TestData.ProjectDocumentEntities);
    //    context.ProjectExpenses.AddRange(TestData.ProjectExpenseEntities);
    //    context.ProjectSchedules.AddRange(TestData.ProjectScheduleEntities);
    //    context.Projects.AddRange(TestData.ProjectEntities);

    //    await context.SaveChangesAsync();
    //}
}
