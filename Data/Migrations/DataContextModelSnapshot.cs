﻿// <auto-generated />
using System;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.CustomerAddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerContactId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCodeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerContactId");

                    b.HasIndex("PostalCodeId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("Data.Entities.CustomerContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("CustomerContacts");
                });

            modelBuilder.Entity("Data.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Data.Entities.CustomerTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("Data.Entities.PostalCodeEntity", b =>
                {
                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostalCode");

                    b.ToTable("PostalCodes");
                });

            modelBuilder.Entity("Data.Entities.ProjectDocumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileDirectory")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("UploadedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UploadedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectDocuments");
                });

            modelBuilder.Entity("Data.Entities.ProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusTypeEntityId")
                        .HasColumnType("int");

                    b.Property<int>("StatusTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StatusTypeEntityId");

                    b.HasIndex("StatusTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Data.Entities.ProjectExpenseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(20, 2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpenseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectExpenses");
                });

            modelBuilder.Entity("Data.Entities.ProjectLogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChangedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ChangedNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectLogs");
                });

            modelBuilder.Entity("Data.Entities.ProjectScheduleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSchedules");
                });

            modelBuilder.Entity("Data.Entities.ProjectServiceEntity", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("EstimatedHours")
                        .HasColumnType("decimal(20, 2)");

                    b.Property<int?>("ProjectEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceEntityId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "ServiceId");

                    b.HasIndex("ProjectEntityId");

                    b.HasIndex("ServiceEntityId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ProjectServices");
                });

            modelBuilder.Entity("Data.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.Entities.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("HourlyCost")
                        .HasColumnType("decimal(20, 2)");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Data.Entities.StatusTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusType")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("StatusType")
                        .IsUnique();

                    b.ToTable("StatusTypes");
                });

            modelBuilder.Entity("Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Entities.CustomerAddressEntity", b =>
                {
                    b.HasOne("Data.Entities.CustomerContactEntity", "CustomerContact")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.PostalCodeEntity", "PostalCode")
                        .WithMany()
                        .HasForeignKey("PostalCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerContact");

                    b.Navigation("PostalCode");
                });

            modelBuilder.Entity("Data.Entities.CustomerContactEntity", b =>
                {
                    b.HasOne("Data.Entities.CustomerEntity", "Customer")
                        .WithMany("CustomerContacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Data.Entities.CustomerEntity", b =>
                {
                    b.HasOne("Data.Entities.CustomerTypeEntity", "CustomerType")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("Data.Entities.ProjectDocumentEntity", b =>
                {
                    b.HasOne("Data.Entities.ProjectEntity", "Project")
                        .WithMany("ProjectDocuments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Data.Entities.ProjectEntity", b =>
                {
                    b.HasOne("Data.Entities.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.StatusTypeEntity", null)
                        .WithMany("Projects")
                        .HasForeignKey("StatusTypeEntityId");

                    b.HasOne("Data.Entities.StatusTypeEntity", "StatusType")
                        .WithMany()
                        .HasForeignKey("StatusTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("StatusType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.ProjectExpenseEntity", b =>
                {
                    b.HasOne("Data.Entities.ProjectEntity", "Project")
                        .WithMany("ProjectExpenses")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Data.Entities.ProjectLogEntity", b =>
                {
                    b.HasOne("Data.Entities.ProjectEntity", "Project")
                        .WithMany("ProjectLogs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Data.Entities.ProjectScheduleEntity", b =>
                {
                    b.HasOne("Data.Entities.ProjectEntity", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Data.Entities.ProjectServiceEntity", b =>
                {
                    b.HasOne("Data.Entities.ProjectEntity", null)
                        .WithMany("ProjectServices")
                        .HasForeignKey("ProjectEntityId");

                    b.HasOne("Data.Entities.ProjectEntity", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.ServiceEntity", null)
                        .WithMany("ProjectServices")
                        .HasForeignKey("ServiceEntityId");

                    b.HasOne("Data.Entities.ServiceEntity", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Data.Entities.UserEntity", b =>
                {
                    b.HasOne("Data.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Entities.CustomerContactEntity", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("Data.Entities.CustomerEntity", b =>
                {
                    b.Navigation("CustomerContacts");
                });

            modelBuilder.Entity("Data.Entities.CustomerTypeEntity", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Data.Entities.ProjectEntity", b =>
                {
                    b.Navigation("ProjectDocuments");

                    b.Navigation("ProjectExpenses");

                    b.Navigation("ProjectLogs");

                    b.Navigation("ProjectServices");
                });

            modelBuilder.Entity("Data.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Entities.ServiceEntity", b =>
                {
                    b.Navigation("ProjectServices");
                });

            modelBuilder.Entity("Data.Entities.StatusTypeEntity", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
