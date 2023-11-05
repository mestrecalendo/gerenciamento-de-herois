using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Heroi.Api.DTOs
{
    public class ReadHeroiDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string NomeHeroi { get; set; }

        public DateTime DataNascimento { get; set; }
        
        public float Altura { get; set; }

        public float Peso { get; set; }

        public virtual ICollection<ReadSuperpoderDto> Superpoderes { get; set; }
    }
}
