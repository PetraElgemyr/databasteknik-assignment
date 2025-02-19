using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectScheduleRepository(DataContext context) : BaseRepository<ProjectScheduleEntity>(context), IProjectScheduleRepository
{
}

