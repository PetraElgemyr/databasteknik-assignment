using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public DbSet<CustomerAddressEntity> CustomerAddresses { get; set; }
    public DbSet<CustomerContactEntity> CustomerContacts { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<CustomerTypeEntity> CustomerTypes { get; set; }
    public DbSet<PostalCodeEntity> PostalCodes { get; set; }
    public DbSet<ProjectDocumentEntity> ProjectDocuments { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ProjectExpenseEntity> ProjectExpenses { get; set; }
    public DbSet<ProjectLogEntity> ProjectLogs { get; set; }
    public DbSet<ProjectScheduleEntity> ProjectSchedules { get; set; }
    public DbSet<ProjectServiceEntity> ProjectServices { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectServiceEntity>()
            .HasKey(x => new { x.ProjectId, x.ServiceId });

        modelBuilder.Entity<ProjectServiceEntity>()
            .HasOne(x => x.Project)
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectServiceEntity>()
            .HasOne(x => x.Service)
            .WithMany()
            .HasForeignKey(x => x.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<ProjectEntity>()
        .HasOne(p => p.User)
        .WithMany()
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Customer)
            .WithMany()
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.StatusType)
            .WithMany()
            .HasForeignKey(p => p.StatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
           .HasOne(p => p.ProjectSchedule)
           .WithOne()
           .HasForeignKey<ProjectEntity>(p => p.ProjectScheduleId)
           .OnDelete(DeleteBehavior.Cascade);

    }




}
