using Data.Entities;

namespace Data.Interfaces;

public interface IProjectServiceRepository : IBaseRepository<ProjectServiceEntity>
{
    Task<IEnumerable<ProjectServiceEntity>?> GetAllProjectServicesByProjectIdAsync(int projectId);
    Task<bool> RemoveAsyncByFKKeys(int projectId, int serviceId);
}

