using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectExpenseRepository(DataContext context) : BaseRepository<ProjectExpenseEntity>(context), IProjectExpenseRepository
{
}

