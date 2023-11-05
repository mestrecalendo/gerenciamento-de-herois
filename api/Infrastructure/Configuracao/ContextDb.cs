
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuracao
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<Herois> Herois { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        private static string GetConnectionString()
        {
            return "server=localhost;database=super_herois;User=root;Password=root;";
        }
    }
}
