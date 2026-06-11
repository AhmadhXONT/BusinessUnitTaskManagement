namespace BusinessUnit.Domain;

public class BusinessUnit
{
    public int Id { get; set; }
    public string BusinessUnitCode { get; set; } = string.Empty; // Maps to BusinessUnit in DB
    public string BusinessUnitName { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string TelephoneNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? Logo { get; set; }
    public string? District { get; set; }
}