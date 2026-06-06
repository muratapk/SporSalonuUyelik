namespace SporSalonuUyelik.Models
{
    public class Antrenor
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; }=string.Empty;

        public string UzmanlikAlani { get; set; } = string.Empty;

        public string Telefon { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
