
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuracao
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Superpoder> Superpoderes { get; set; }
    }
}
