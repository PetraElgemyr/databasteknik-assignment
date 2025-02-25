using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));


builder.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
builder.Services.AddScoped<ICustomerAddressService, CustomerAddressService>();

builder.Services.AddScoped<ICustomerContactRepoitory, CustomerContactRepoitory>();
builder.Services.AddScoped<ICustomerContactService, CustomerContactService>();

builder.Services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
builder.Services.AddScoped<ICustomerTypeService, CustomerTypeService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();
builder.Services.AddScoped<IPostalCodeService, PostalCodeService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IProjectScheduleRepository, ProjectScheduleRepository>();

builder.Services.AddScoped<IProjectServiceRepository, ProjectServiceRepository>();
builder.Services.AddScoped<IProjectServiceService, ProjectServiceService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();

builder.Services.AddScoped<IStatusTypeRepository, StatusTypeRepository>();
builder.Services.AddScoped<IStatusTypeService, StatusTypeService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddMemoryCache();


var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();
app.Run();
