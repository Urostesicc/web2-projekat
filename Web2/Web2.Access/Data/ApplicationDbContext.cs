using Microsoft.EntityFrameworkCore;
using Web2.Models;

namespace Web2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Korisnici { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Narudzbina> Narudzbine { get; set; }

    }
}
