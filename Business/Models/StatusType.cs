using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class StatusType
{
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;
}
