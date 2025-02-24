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
        ];
}
