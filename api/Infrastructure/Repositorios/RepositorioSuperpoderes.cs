using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositorios
{
    public class RepositorioSuperpoderes : ISuperpoder
    {
        private readonly DbContextOptions<ContextDb> _OptionsBuilder;

        public RepositorioSuperpoderes()
        {
            _OptionsBuilder = new DbContextOptions<ContextDb>();
        }

        public async Task<IList<Superpoderes>> ListarSuperpoderes()
        {
            using var banco = new ContextDb(_OptionsBuilder);
            return await
                banco.Superpoderes
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
