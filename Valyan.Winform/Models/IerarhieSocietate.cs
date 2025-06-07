public class IerarhieSocietate
{
    public int IerarhieID { get; set; }
    public int SocietateParinteID { get; set; }
    public int SocietateCopiID { get; set; }
    public decimal? ProcentDetinere { get; set; }
    public DateTime DataIncepere { get; set; }
    public DateTime? DataSfarsit { get; set; }
    public bool StatusActiv { get; set; }
}