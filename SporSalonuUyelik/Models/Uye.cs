namespace SporSalonuUyelik.Models
{
    public class Uye
    {
        public int Id { get; set; }

        public string Ad { get; set; } = string.Empty;

        public string Soyad { get; set; }=string.Empty;

        public string Telefon { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime ? DogumTarihi { get; set; }

        public string Adres { get; set; } = string.Empty;

        public DateTime? KayitTarihi { get; set; } = DateTime.Now;

        public bool  AktifMi { get; set; }

        public ICollection<Uyelik>? Uyelikler { get; set; }
    }
}
