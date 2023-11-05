using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Heroi.Api.DTOs
{
    public class UpdateHeroiDto
    {
        [MaxLength(120, ErrorMessage = "Nome deve ter no máximo 120 caracteres!")]
        public string Nome { get; set; }

        [MaxLength(120, ErrorMessage = "NomeHeroi deve ter no máximo 120 caracteres!")]
        public string NomeHeroi { get; set; }

        public DateTime DataNascimento { get; set; }

        public float Altura { get; set; }

        public float Peso { get; set; }

        public ICollection<Superpoderes> Superpoderes { get; set; }
    }
}
