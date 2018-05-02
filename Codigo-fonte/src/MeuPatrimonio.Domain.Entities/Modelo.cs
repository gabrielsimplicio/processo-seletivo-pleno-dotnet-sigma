using System.Collections.Generic;

namespace MeuPatrimonio.Domain.Entities
{
    public class Modelo : EntityBase
    {
        public string Nome { get; set; }
        public Marca Marca { get; set; }
        public int MarcaId { get; set; }

        public IList<Patrimonio> Patrimonios { get; set; }
    }
}
