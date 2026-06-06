using System.ComponentModel.DataAnnotations;

namespace SporSalonuUyelik.Models
{
    public class Uyelik
    {
        public int Id { get; set; }

        [Display(Name = "Üye Adı")]
        public int? UyeId { get; set; }

        public Uye? Uye { get; set; }
        [Display(Name = "Üyelik Paketi")]
        public int? UyelikPaketiId { get; set; }

        public UyelikPaketi? UyelikPaketi { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? BaslangicTarihi { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool AktifMi { get; set; }
    }
}
