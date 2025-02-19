using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectManagerFactory
{
    public static ProjectManager Create(UserEntity user)
    {
        return new ProjectManager
        {
            Id = user.Id,
            Name = $"{user.FirstName} {user.LastName}"
        };
    }
}
