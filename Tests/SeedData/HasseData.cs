using Data.Entities;

namespace Tests.SeedData;

public static class HasseData
{

  
}

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




//    public static readonly ServiceEntity[] ServiceEntities = [
//        new ServiceEntity{Id = 1, ServiceType = "Konsulttjänst", HourlyCost = 1900 },
//        new ServiceEntity{Id = 2, ServiceType = "Konsulttjänst", HourlyCost = 1200 },
//        new ServiceEntity{Id = 3, ServiceType = "Anställning", HourlyCost = 499 }

//        ];


