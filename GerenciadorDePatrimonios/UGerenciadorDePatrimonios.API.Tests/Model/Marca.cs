using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGerenciadorDePatrimonios.API.Tests
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual IEnumerable<Modelo> Modelos { get; set; }
    }
}
