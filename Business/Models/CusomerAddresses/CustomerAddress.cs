namespace Business.Models.CusomerAddresses;

public class CustomerAddress
{
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string PostalCodeId { get; set; } = null!;
    public int  CustomerContactId { get; set; } 
}
