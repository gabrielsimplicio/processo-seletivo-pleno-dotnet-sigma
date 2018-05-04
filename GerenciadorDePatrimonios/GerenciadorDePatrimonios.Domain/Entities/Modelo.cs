namespace GerenciadorDePatrimonios.Domain.Entities
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
