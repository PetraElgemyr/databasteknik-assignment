using Business.Models.ProjectServices;
using Business.Services;
using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models.Projects;

public class ProjectRegistrationForm
{
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal TotalCost { get; set; }
    public int CustomerId { get; set; }
    public int StatusTypeId { get; set; }
    public int UserId { get; set; }
    public ProjectSchedule ProjectSchedule { get; set; } = null!;
    public ProjectServiceRegistrationFromNewProject ProjectService { get; set; } = null!;
}


