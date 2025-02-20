using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class CustomerType
{
    public int Id { get; set; }
    public string CustomerTypeName { get; set; } = null!;
}
