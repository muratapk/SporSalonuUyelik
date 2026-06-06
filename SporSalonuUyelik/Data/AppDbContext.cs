using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using SporSalonuUyelik.Models;

namespace SporSalonuUyelik.Data
{
    public class AppDbContext: IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Uyelik> Uyelikler { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<UyelikPaketi> UyelikPaketleri { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<Antrenor> Antrenorler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
    }
}
