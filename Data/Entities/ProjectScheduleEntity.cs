using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectScheduleEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
}