using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectDocumentEntity
{
    [Key]
    public int Id { get; set; }
 
    [Column(TypeName = "nvarchar(300)")]
    public string FileName { get; set; } = null!;

    [Column(TypeName = "nvarchar(300)")]
    public string FileDirectory { get; set; } = null!;

    [Column(TypeName = "nvarchar(200)")]
    public string UploadedBy { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(50)")]
    public string FileType { get; set; } = null!;
    public DateTime UploadedDate { get; set; }


    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
}