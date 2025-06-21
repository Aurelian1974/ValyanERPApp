public class PartnerAddress
{
    public int PartnerAddressId { get; set; }
    public Guid PartnerAddressGUID { get; set; }
    public string? SyntheticName { get; set; }
    public int PartnerId { get; set; }
    public Guid PartnerGUID { get; set; }
    public string? Street { get; set; }
    public string? LocalNumber { get; set; }
    public string? BuildingNumber { get; set; }
    public string? FlatNumber { get; set; }
    public string? ZipCode { get; set; }
    public int? CityId { get; set; }
    public int? IdJudet { get; set; }
    public Guid? JudetGuid { get; set; }
    public int? CountryId { get; set; }
    public bool IsDefault { get; set; }
    public int? CommercialZoneId { get; set; }
    public string? StreetNumber { get; set; }
    public string? StairNumber { get; set; }
    public string? FloorNumber { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? Fax { get; set; }
    public string? PostalCode { get; set; }
    public string? ContactPerson { get; set; }
    public string? EMail { get; set; }
    public string? FiscalCode { get; set; }
    public string? FreeTxt { get; set; }
}