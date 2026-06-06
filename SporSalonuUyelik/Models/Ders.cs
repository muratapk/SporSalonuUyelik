namespace SporSalonuUyelik.Models
{
    public class Ders
    {
        public int Id { get; set; }

        public string DersAdi { get; set; } = string.Empty;

        public DateTime? DersTarihi { get; set; }

        public int? Kontenjan { get; set; }

        public int? AntrenorId { get; set; }

        public Antrenor? Antrenor { get; set; }
    }
}
