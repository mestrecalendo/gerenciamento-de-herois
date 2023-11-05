
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
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HeroisSuperpoderes>().HasKey(sessao => new { sessao.HeroiId, sessao.SuperpoderId });


            builder.Entity<HeroisSuperpoderes>().HasOne(sessao => sessao.Heroi)
                .WithMany(cinema => cinema.Superpoderes)
                .HasForeignKey(sessao => sessao.HeroiId);

            base.OnModelCreating(builder);
        }

        private static string GetConnectionString()
        {
            return "server=localhost;database=super_herois;User=root;Password=root;";
        }
    }
}
