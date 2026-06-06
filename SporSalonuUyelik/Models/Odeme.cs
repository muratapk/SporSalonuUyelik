namespace SporSalonuUyelik.Models
{
    public class Odeme
    {
        public int Id { get; set; }

        public int? UyeId { get; set; }

        public Uye Uye { get; set; }

        public decimal? Tutar { get; set; }

        public DateTime OdemeTarihi { get; set; }

        public string OdemeTipi { get; set; } = string.Empty;

        public string Aciklama { get; set; } = string.Empty;
    }
}
