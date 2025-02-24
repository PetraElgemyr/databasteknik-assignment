using Business.Models.Customers;
using Business.Models.Users;

namespace Business.Models.Projects;

public class ProjectUpdateForm
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal TotalCost { get; set; }
    public int CustomerId { get; set; }
    public int StatusTypeId { get; set; }
    public int UserId { get; set; }
    public ProjectSchedule ProjectSchedule { get; set; } = null!;

}

//public class ProjectRegistrationForm
//{
//    public string ProjectName { get; set; } = null!;
//    public string Description { get; set; } = null!;
//    public decimal TotalCost { get; set; }
//    public int CustomerId { get; set; }
//    public int StatusTypeId { get; set; }
//    public int UserId { get; set; }
//    public ProjectSchedule ProjectSchedule { get; set; } = null!;
//}
