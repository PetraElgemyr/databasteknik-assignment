namespace Business.Models.ProjectServices;
public class ProjectServiceRegistrationForm
{
    public decimal EstimatedHours { get; set; }
    public int ProjectId { get; set; }
    public ServiceRegistration Service { get; set; } = null!;
}
