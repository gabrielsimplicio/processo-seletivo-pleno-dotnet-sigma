using System.Collections.Generic;

namespace MeuPatrimonio.Domain.Entities
{
    public class Marca : EntityBase
    {
        public string Nome { get; set; }
        public IList<Modelo> Modelos { get; set; }

        public Marca()
        {

        }
    }
}
