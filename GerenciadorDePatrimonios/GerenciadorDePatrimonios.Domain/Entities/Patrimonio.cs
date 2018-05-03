using System;

namespace GerenciadorDePatrimonios.Domain.Entities
{
    public class Patrimonio
    {
        public int PatrimonioId { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public int ModeloId { get; set; }
        public virtual Modelo Modelo { get; set; }
        public string Descricao { get; set; }
        public Guid NumeroTombo { get; set; }
        public Patrimonio() => NumeroTombo = new Guid();
    }
}
