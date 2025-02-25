namespace Business.Models.ProjectServices;

public class ProjectServiceWithDetails
{
    public int ProjectId { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
}

