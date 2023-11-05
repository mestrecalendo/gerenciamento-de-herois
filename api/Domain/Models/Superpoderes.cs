using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Superpoderes
    {
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string Descricao { get; set; }
        public ICollection<HeroisSuperpoderes> Herois { get; set; }
    }
}
