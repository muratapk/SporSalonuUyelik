namespace SporSalonuUyelik.Models
{
    public class UyelikPaketi
    {
        public int Id { get; set; }

        public string PaketAdi { get; set; }=string.Empty;

        public int? SureGun { get; set; }

        public decimal? Ucret { get; set; }

        public string Aciklama { get; set; } = string.Empty;

        public ICollection<Uyelik> ? Uyelikler { get; set; }
    }
}
