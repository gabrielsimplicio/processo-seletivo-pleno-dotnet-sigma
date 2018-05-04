using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGerenciadorDePatrimonios.API.Tests
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
