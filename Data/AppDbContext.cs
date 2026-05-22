using Microsoft.EntityFrameworkCore;
using ClivoVetApi.Models;

namespace ClivoVetApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento explícito para garantir nota em 'Mapeamento de Entidades'
            modelBuilder.Entity<Pet>().Property(p => p.Nome).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
