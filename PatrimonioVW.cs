namespace LuisCesarMVCWebApi.ViewModel
{
    public class PatrimonioVW
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public string MarcaNome { get; set; }
        public int ModeloId { get; set; }
        public string ModeloNome { get; set; }

        public string NumeroTombo { get; set; }
    }
}