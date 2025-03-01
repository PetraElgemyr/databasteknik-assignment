using Data.Entities;

namespace Tests.SeedData;

public static class TestData
{
    public static readonly RoleEntity[] RoleEntities = [
       new RoleEntity{Id = 1, RoleName = "Projektledare" },
        new RoleEntity{Id = 2, RoleName = "Utvecklare" },
        new RoleEntity{Id = 3, RoleName = "Designer" },
        new RoleEntity{Id = 4, RoleName = "Utbildare" },
    ];


    public static readonly PostalCodeEntity[] PostalCodeEntities = [
     new PostalCodeEntity{
                PostalCode = "12056",
                City = "Stockholm"
            },
            new PostalCodeEntity{
                PostalCode = "12149",
                City = "Stockholm"
            },
              new PostalCodeEntity{
                PostalCode = "11723",
                City = "Stockholm"
            },
        ];



    public static readonly CustomerAddressEntity[] CustomerAddressEntities = [
             new CustomerAddressEntity{
            Id = 1,
            StreetName = "Storgatan",
            StreetNumber = "29",
            PostalCodeId ="12056",
            CustomerContactId = 1
        },
        new CustomerAddressEntity{
            Id = 2,
            StreetName = "Vegagatan",
            StreetNumber = "17",
            PostalCodeId = "12149",
            CustomerContactId = 2
        }
        ];

    //public static readonly CustomerAddressEntity[] CustomerAddressEntities = [

    //    new CustomerAddressEntity{
    //        Id = 3,
    //        StreetName = "Hjälmarsvägen",
    //        StreetNumber = "51",
    //        PostalCodeId = PostalCodeEntities![1].PostalCode,
    //        CustomerContactId = CustomerContactEntities![2].Id
    //    }
    //   ];

    public static readonly UserEntity[] UserEntities = [
        new UserEntity{
            Id = 1,
            FirstName = "Herman",
            LastName = "Hermansson",
            Email = "h@domain.com",
            PhoneNumber= "",
            RoleId = RoleEntities[1].Id
        },
        new UserEntity{
            Id = 2,
            FirstName = "Anders",
            LastName = "Andersson",
            Email = "a@domain.com",
            PhoneNumber= "",
            RoleId = RoleEntities[2].Id
        },
        new UserEntity{
            Id = 3,
            FirstName = "Karl",
            LastName = "Karlsson",
            Email = "k@domain.com",
            PhoneNumber= "",
            RoleId = RoleEntities[0].Id
        },
          new UserEntity{
            Id = 4,
            FirstName = "Bertil",
            LastName = "Bertsson",
            Email = "bert@domain.com",
            PhoneNumber= "",
            RoleId = RoleEntities[0].Id
        },
        ];

    public static readonly CustomerTypeEntity[] CustomerTypeEntities = [
        new CustomerTypeEntity { Id = 1, CustomerTypeName = "Företag" },
        new CustomerTypeEntity { Id = 2, CustomerTypeName = "Privatperson" },
    ];


    public static readonly CustomerEntity[] CustomerEntities = [
        new CustomerEntity{ Id = 1, CustomerName = "Arvid Vigren", CustomerTypeId = CustomerTypeEntities![1].Id},
        new CustomerEntity{ Id = 2, CustomerName = "EPN Sverige AB", CustomerTypeId = CustomerTypeEntities![0].Id},
        new CustomerEntity{ Id = 3, CustomerName = "Nackademin AB", CustomerTypeId = CustomerTypeEntities![0].Id},
    ];


    public static readonly StatusTypeEntity[] StatusTypeEntities = [
        new StatusTypeEntity {Id = 1, StatusTypeName = "Ej påbörjad" },
        new StatusTypeEntity {Id = 2, StatusTypeName = "Pågående" },
        new StatusTypeEntity {Id = 3, StatusTypeName = "Avslutad" },
    ];


    public static readonly ProjectEntity[] ProjectEntities = [
          new ProjectEntity{
                Id = 1,
                ProjectName = "Projekt 1",
                Description = "Beskrivning av projekt 1",
                TotalCost = 10000000,
                CustomerId = CustomerEntities[0].Id,
                StatusTypeId = StatusTypeEntities![0].Id ,
                UserId = UserEntities[0].Id,
                ProjectScheduleId = 1
            },
         new ProjectEntity{
                Id = 2,
                ProjectName = "Projekt 2",
                Description = "Beskrivning av projekt 2",
                TotalCost = 22000000,
                CustomerId = CustomerEntities[1].Id,
                StatusTypeId = StatusTypeEntities[1].Id ,
                UserId = UserEntities[1].Id,
                ProjectScheduleId = 2

            },
        ];

    public static readonly ProjectLogEntity[] ProjectLogs = [
        new ProjectLogEntity{
            Id = 1,
            LogDate = DateTime.Now,
            ChangedBy = "Herman Hermansson",
            ChangedNotes = "Loggtext 1",
            ProjectId = ProjectEntities![0].Id,
        },
         new ProjectLogEntity{
            Id = 2,
            LogDate = DateTime.Now,
            ChangedBy = "Karl Karlsson",
            ChangedNotes = "Loggtext 2",
            ProjectId = ProjectEntities![1].Id,
        },
        ];

    public static readonly ProjectExpenseEntity[] ProjectExpenses = [
          new ProjectExpenseEntity{
              Id = 1,
              ExpenseType = "Resa",
              Amount = 15000,
              Description = "Resa till Stockholm inklusive boende",
              ExpenseDate = DateTime.Now,
              ProjectId = ProjectEntities![0].Id,
          },
        new ProjectExpenseEntity{
             Id = 2,
             ExpenseType = "Materiel",
             Amount = 95000,
             Description = "Kontorsmaterial såsom stolar, skrivbord, datorskärmar osv.",
             ExpenseDate = DateTime.Now,
             ProjectId = ProjectEntities![0].Id,
        },
        ];

    public static readonly ServiceEntity[] ServiceEntities = [
        new ServiceEntity{Id = 1, ServiceTypeName = "Konsult", ServiceName="Projektledning", HourlyCost = 1900 },
        new ServiceEntity{Id = 2, ServiceTypeName = "Konsult", ServiceName="Design",HourlyCost = 1200 },
        new ServiceEntity{Id = 3, ServiceTypeName = "Anställd", ServiceName="Utbildning", HourlyCost = 499 }
        ];

    public static readonly ProjectServiceEntity[] ProjectServiceEntities = [
        new ProjectServiceEntity{
            ProjectId = ProjectEntities![0].Id,
            ServiceId = ServiceEntities![0].Id,
            EstimatedHours = 100
        },

        new ProjectServiceEntity{
            ProjectId = ProjectEntities![0].Id,
            ServiceId = ServiceEntities![1].Id,
             EstimatedHours = 50
        }
        ];

    public static readonly ProjectScheduleEntity[] ProjectScheduleEntities = [
     new ProjectScheduleEntity{
         Id =1,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(30),
        },
        new ProjectScheduleEntity{
                     Id =2,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(180),
            },
    ];

    public static readonly CustomerContactEntity[] CustomerContactEntities = [
        new CustomerContactEntity{
                Id = 1,
                FirstName = "Arvid",
                LastName = "Vigren",
                Email = "vigren@icloud.com",
                PhoneNumber = "070-1234567",
                CustomerId = CustomerEntities![0].Id,
            },
             new CustomerContactEntity{
                Id = 2,
                FirstName = "Hans",
                LastName = "Mattin-Lassei",
                Email = "hans@domain.se",
                PhoneNumber = "0184929433",
                CustomerId = CustomerEntities![1].Id,
            },
                  new CustomerContactEntity{
                Id = 3,
                FirstName = "Gunilla",
                LastName = "Simonsson",
                Email = "Gunilla@domain.se",
                PhoneNumber = "0184929433",
                CustomerId = CustomerEntities![1].Id,
            },
        ];


}
