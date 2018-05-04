using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        //public virtual IEnumerable<Modelo> Modelos { get; set; }
    }
}
