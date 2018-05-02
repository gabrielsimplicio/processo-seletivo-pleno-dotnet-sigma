using System;
using System.Linq;

namespace ProjetoSigma.Application.ViewModel
{
    public class PatrimonioViewModel : BaseEntityApp
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tombo { get; private set; }
        public int ModeloId { get; set; }
        public virtual ModeloViewModel Modelo { get; set; }
        public int MarcaId { get; set; }
        public virtual MarcaViewModel Marca { get; set; }

        public void GerarTombo()
        {
            var prefix = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            var random = new Random();
            Tombo = DateTime.Today.Year + "." + new string(Enumerable.Repeat(prefix, prefix.Length - 5).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}