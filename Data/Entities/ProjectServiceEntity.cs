using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectServiceEntity
{
    [Column(TypeName = "decimal(20, 2)")]
    public decimal EstimatedHours { get; set; }

    [ForeignKey("Project")]
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
    [ForeignKey("Service")]
    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;
}