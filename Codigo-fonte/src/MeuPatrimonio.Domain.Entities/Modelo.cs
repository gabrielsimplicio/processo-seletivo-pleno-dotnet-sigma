namespace MeuPatrimonio.Domain.Entities
{
    public class Modelo : EntityBase
    {
        public string Nome { get; set; }
        public Marca Marca { get; set; }
    }
}
