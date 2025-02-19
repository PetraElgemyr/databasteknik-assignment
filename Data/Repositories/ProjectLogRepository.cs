using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectLogRepository(DataContext context) : BaseRepository<ProjectLogEntity>(context), IProjectLogRepository
{
}

