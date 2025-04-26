using Microsoft.EntityFrameworkCore;
using FutbolPeruano.Models; // <- ¡Agregado!

namespace FutbolPeruano.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}
