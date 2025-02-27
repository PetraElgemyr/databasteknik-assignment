using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectManagerFactory
{
    public static ProjectManager? Create(UserEntity user) => user == null ? null : new ProjectManager
    {
        Id = user.Id,
        Name = $"{user.FirstName} {user.LastName}"
    };
}
