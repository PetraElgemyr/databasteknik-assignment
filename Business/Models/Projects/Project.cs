namespace Business.Models.Projects;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal TotalCost { get; set; }
    public int CustomerId { get; set; } 
    public int StatusTypeId { get; set; } 
    public int UserId { get; set; } 
}
