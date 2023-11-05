using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Herois
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public virtual ICollection<HeroisSuperpoderes> Superpoderes { get; set; }
    }
}
