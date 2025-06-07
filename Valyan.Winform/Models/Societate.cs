public class Societate
{
    public int SocietateID { get; set; }
    public string Nume { get; set; } = string.Empty;
    public string? CodFiscal { get; set; }
    public int? SocietateParinteID { get; set; }
    public DateTime? DataInfiintarii { get; set; }
    public bool StatusActiv { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}