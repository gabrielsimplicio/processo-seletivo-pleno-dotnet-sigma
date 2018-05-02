namespace MeuPatrimonio.Domain.Entities
{
    public class Patrimonio : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public readonly int Tombo;

        public Patrimonio()
        {

        }
    }
}
