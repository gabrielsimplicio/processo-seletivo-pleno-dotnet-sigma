namespace MeuPatrimonio.Domain.DTOs
{
    public class PatrimonioDTO : DTOBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public int Tombo { get; set; }

        public PatrimonioDTO()
        {

        }
    }
}
