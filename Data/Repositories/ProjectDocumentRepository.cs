using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectDocumentRepository(DataContext context) : BaseRepository<ProjectDocumentEntity>(context), IProjectDocumentRepository
{
}

