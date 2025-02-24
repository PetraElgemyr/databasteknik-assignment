namespace Business.Models.Projects;

public class ListProject
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal TotalCost { get; set; }
    public string CustomerName { get; set; } = null!;
    public string StatusTypeName { get; set; } = null!;
}
