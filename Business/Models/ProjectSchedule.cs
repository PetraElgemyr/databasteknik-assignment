namespace Business.Models;

public class ProjectSchedule
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int ProjectId { get; set; }
}
