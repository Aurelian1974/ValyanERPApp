public class Locatie
{
    public int LocatieID { get; set; }
    public int SocietateID { get; set; }
    public string NumeLocatie { get; set; } = string.Empty;
    public string? Adresa { get; set; }
    public string? Oras { get; set; }
    public string? Judet { get; set; }
    public string? CodPostal { get; set; }
    public string Tara { get; set; } = "Romania";
    public string? TipLocatie { get; set; }
    public bool StatusActiv { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}