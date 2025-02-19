using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectLogEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    [Column(TypeName = "nvarchar(200)")]
    public string ChangedBy { get; set; } = null!;
    public string ChangedNotes { get; set; } = null!;

    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
}
