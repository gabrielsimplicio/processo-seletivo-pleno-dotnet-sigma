using System;

namespace GerenciadorPatrimonios.Api.ViewModel
{
    public class PatrimonioViewModel
    {
        
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
        
        //public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public Boolean? Ativo { get; set; }

        public int ModeloId { get; set; }

    }
}