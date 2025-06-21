public class Judet
{
    public int IdJudet { get; set; }
    public Guid JudetGuid { get; set; }
    public string CodJudet { get; set; } = string.Empty;
    public string Nume { get; set; } = string.Empty;
    public int? Siruta { get; set; }
    public string? CodAuto { get; set; }
    public int? Ordine { get; set; }
}