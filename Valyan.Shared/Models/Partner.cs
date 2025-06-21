public class Partner
{
    public int PartnerId { get; set; }
    public Guid PartnerGUID { get; set; }
    public string PartnerCode { get; set; } = string.Empty;
    public string PartnerName { get; set; } = string.Empty;
    public string? Remark { get; set; }
    public string? E_Mail { get; set; }
    public int? HoldingId { get; set; }
    public int? GroupId { get; set; }
    public bool IsUE { get; set; }
    public bool IsNONUE { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FiscalCode { get; set; }
    public string? FiscalAtribute { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ModifyDate { get; set; }
}