using Data.Entities;

namespace Tests.SeedData;

public static class HasseData
{
    //public static readonly RoleEntity[] RoleEntities = [
    //    new RoleEntity{Id = 1, RoleName = "Projektledare" },
    //    new RoleEntity{Id = 2, RoleName = "Utvecklare" },
    //    new RoleEntity{Id = 3, RoleName = "Designer" },
    //    new RoleEntity{Id = 4, RoleName = "Utbildare" },
    //];

  

    //public static readonly UserEntity[] UserEntities = [
    //    new UserEntity{
    //        Id = 1,
    //        FirstName = "Herman",
    //        LastName = "Hermansson",
    //        Email = "h@domain.com",
    //        PhoneNumber= "",
    //        RoleId = RoleEntities[1].Id
    //    },
    //    new UserEntity{
    //        Id = 2,
    //        FirstName = "Anders",
    //        LastName = "Andersson",
    //        Email = "a@domain.com",
    //        PhoneNumber= "",
    //        RoleId = RoleEntities[2].Id
    //    },
    //    new UserEntity{
    //        Id = 3,
    //        FirstName = "Karl",
    //        LastName = "Karlsson",
    //        Email = "k@domain.com",
    //        PhoneNumber= "",
    //        RoleId = RoleEntities[0].Id
    //    },
    //    ];
}
//using Data.Entities;

//namespace Tests.SeedData;

//public static class TestData
//{
//    public static readonly CustomerAddressEntity[] CustomerAddressEntities = [
//        new CustomerAddressEntity{
//            Id = 1,
//            StreetName = "Storgatan",
//            StreetNumber = "29",
//            PostalCodeId = PostalCodeEntities![0].PostalCode,
//            CustomerContactId = CustomerContactEntities![0].Id
//        },

//         new CustomerAddressEntity{
//            Id = 2,
//            StreetName = "Vegagatan",
//            StreetNumber = "17",
//            PostalCodeId = PostalCodeEntities![1].PostalCode,
//            CustomerContactId = CustomerContactEntities![2].Id
//        },
//          new CustomerAddressEntity{
//            Id = 3,
//            StreetName = "Hjälmarsvägen",
//            StreetNumber = "51",
//            PostalCodeId = PostalCodeEntities![1].PostalCode,
//            CustomerContactId = CustomerContactEntities![2].Id
//        }
//    ];

//    public static readonly CustomerContactEntity[] CustomerContactEntities = [
//        new CustomerContactEntity{
//            Id = 1,
//            FirstName = "Arvid",
//            LastName = "Vigren",
//            Email = "vigren@icloud.com",
//            PhoneNumber = "070-1234567",
//            CustomerId = CustomerEntities![0].Id,
//        },
//         new CustomerContactEntity{
//            Id = 2,
//            FirstName = "Hans",
//            LastName = "Mattin-Lassei",
//            Email = "hans@domain.se",
//            PhoneNumber = "0184929433",
//            CustomerId = CustomerEntities![1].Id,
//        },
//              new CustomerContactEntity{
//            Id = 2,
//            FirstName = "Gunilla",
//            LastName = "Simonsson",
//            Email = "Gunilla@domain.se",
//            PhoneNumber = "0184929433",
//            CustomerId = CustomerEntities![2].Id,
//        },
//    ];

//    public static readonly CustomerEntity[] CustomerEntities = [
//      new CustomerEntity{ Id = 1, CustomerName = "Arvid Vigren", CustomerTypeId = CustomerTypeEntities![1].Id},
//      new CustomerEntity{ Id = 2, CustomerName = "EPN Sverige AB", CustomerTypeId = CustomerTypeEntities![0].Id},
//      new CustomerEntity{ Id = 3, CustomerName = "Nackademin AB", CustomerTypeId = CustomerTypeEntities![0].Id},
//    ];

//    public static readonly CustomerTypeEntity[] CustomerTypeEntities = [
//        new CustomerTypeEntity { CustomerType = "Företag" },
//        new CustomerTypeEntity { CustomerType = "Privatperson" },
//    ];


//    public static readonly PostalCodeEntity[] PostalCodeEntities = [
//        new PostalCodeEntity{
//            PostalCode = "12056",
//            City = "Stockholm"
//        },
//        new PostalCodeEntity{
//            PostalCode = "12149",
//            City = "Stockholm"
//        },
//          new PostalCodeEntity{
//            PostalCode = "11723",
//            City = "Stockholm"
//        },
//    ];

//    public static readonly ProjectDocumentEntity[] ProjectDocumentEntities = [
//        new ProjectDocumentEntity{
//            Id = 1,
//            UploadedBy = "Herman Hermansson",
//            FileName = "Projektplan",
//            FileType = "pdf",
//            FileDirectory = "/kskjskscd/dsfkskf",
//            UploadedDate = DateTime.Now,
//            ProjectId = ProjectEntities![0].Id
//        },
//        new ProjectDocumentEntity{
//            Id = 1,
//            UploadedBy = "Hansn",
//            FileName = "Ett dokument",
//            FileType = "pdf",
//            FileDirectory = "/aasdcdcs/srsd",
//            UploadedDate = DateTime.Now,
//            ProjectId = ProjectEntities![1].Id
//        },
//        ];

//    public static readonly ProjectExpenseEntity[] ProjectExpenseEntities = [
//        new ProjectExpenseEntity {

//        }
//        ];

//    public static readonly ProjectLogEntity[] ProjectLogEntities = [
//        new ProjectLogEntity{
//            Id = 1,
//            LogDate = DateTime.Now,
//            ChangedNotes = "Uppdatering av projektets ansvarige.",
//            ChangedBy = "Hasse Lasse"
//        }, 
//        new ProjectLogEntity{
//            Id = 2,
//            LogDate = DateTime.Now,
//            ChangedNotes = "Ändring av projektets slutdatum.",
//            ChangedBy = "Palle Kuling"
//        }
//        ];


//    public static readonly ProjectEntity[] ProjectEntities = [
//      new ProjectEntity{
//            ProjectName = "Projekt 1",
//            Description = "Beskrivning av projekt 1",
//            TotalCost = 10000000,
//            CustomerId = CustomerEntities[0].Id,
//            StatusTypeId = StatusTypeEntities![0].Id ,
//            UserId = UserEntities![2].Id
//        },
//           new ProjectEntity{
//            ProjectName = "Projekt 1",
//            Description = "Beskrivning av projekt 1",
//            TotalCost = 10000000,
//            CustomerId = CustomerEntities[1].Id,
//            StatusTypeId = StatusTypeEntities[1].Id ,
//            UserId = UserEntities[0].Id
//        },

//    ];

//    public static readonly ProjectScheduleEntity[] ProjectScheduleEntities = [
//        new ProjectScheduleEntity{
//            StartDate = DateTime.Now,
//            EndDate = DateTime.Now.AddDays(30),
//            ProjectId = ProjectEntities![0].Id
//        },

//            new ProjectScheduleEntity{
//            StartDate = DateTime.Now,
//            EndDate = DateTime.Now.AddDays(180),
//            ProjectId = ProjectEntities![1].Id
//        },
//        ];

//    public static readonly ProjectServiceEntity[] ProjectServiceEntities = [
//        new ProjectServiceEntity{
//            ProjectId = ProjectEntities![0].Id,
//            ServiceId = ServiceEntities![0].Id,
//        },

//          new ProjectServiceEntity{
//            ProjectId = ProjectEntities![0].Id,
//            ServiceId = ServiceEntities![2].Id,
//        }
//        ];


//    public static readonly RoleEntity[] RoleEntities = [
//        new RoleEntity{Id = 1, RoleName = "Projektledare" },
//        new RoleEntity{Id = 2, RoleName = "Utvecklare" },
//        new RoleEntity{Id = 3, RoleName = "Designer" },
//        new RoleEntity{Id = 4, RoleName = "Utbildare" },
//    ];


//    public static readonly ServiceEntity[] ServiceEntities = [
//        new ServiceEntity{Id = 1, ServiceType = "Konsulttjänst", HourlyCost = 1900 },
//        new ServiceEntity{Id = 2, ServiceType = "Konsulttjänst", HourlyCost = 1200 },
//        new ServiceEntity{Id = 3, ServiceType = "Anställning", HourlyCost = 499 }

//        ];


//    public static readonly StatusTypeEntity[] StatusTypeEntities = [
//        new StatusTypeEntity {Id = 1, StatusType = "Ej påbörjad" },
//        new StatusTypeEntity {Id = 2, StatusType = "Pågående" },
//        new StatusTypeEntity {Id = 3, StatusType = "Avslutad" },
//        ];

//    public static readonly UserEntity[] UserEntities = [
//        new UserEntity{
//            Id = 1,
//            FirstName = "Herman",
//            LastName = "Hermansson",
//            Email = "h@domain.com",
//            PhoneNumber= "",
//            RoleId = RoleEntities[1].Id
//        },
//        new UserEntity{
//            Id = 2,
//            FirstName = "Anders",
//            LastName = "Andersson",
//            Email = "a@domain.com",
//            PhoneNumber= "",
//            RoleId = RoleEntities[2].Id
//        },
//        new UserEntity{
//            Id = 3,
//            FirstName = "Karl",
//            LastName = "Karlsson",
//            Email = "k@domain.com",
//            PhoneNumber= "",
//            RoleId = RoleEntities[0].Id
//        },
//        ];
//}
