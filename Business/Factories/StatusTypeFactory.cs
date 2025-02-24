using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusTypeFactory
{

    public static StatusType Create(StatusTypeEntity statusType)
    {
        return new StatusType
        {
            Id = statusType.Id,
            StatusName = statusType.StatusTypeName
        };
    }
}
