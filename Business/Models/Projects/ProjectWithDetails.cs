using Business.Models.Customers;
using Business.Models.Users;

namespace Business.Models.Projects;

public class ProjectWithDetails
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal TotalCost { get; set; }
    public Customer Customer { get; set; } = null!;
    public StatusType StatusType { get; set; } = null!;
    public User User { get; set; } = null!;
}
