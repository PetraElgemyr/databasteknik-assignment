using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models.Roles;

public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;
}


