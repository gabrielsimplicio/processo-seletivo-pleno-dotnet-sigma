using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorPatrimonios.Domain
{
    public class Patrimonio
    {

        public Patrimonio()
        {
            this.DataInclusao = DateTime.Now;
            this.Ativo = true;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int? NumeroTombo { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public Boolean? Ativo { get; set; }

        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }
        
    }
}
