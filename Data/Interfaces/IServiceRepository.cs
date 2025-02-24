using Data.Entities;

namespace Data.Interfaces;

public interface IServiceRepository : IBaseRepository<ServiceEntity>
{
    Task<IEnumerable<ServiceEntity?>> GetAllServicesByServiceType(string serviceType);
}

