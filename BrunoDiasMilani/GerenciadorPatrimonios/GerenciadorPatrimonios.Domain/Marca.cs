using System;
using System.Collections.Generic;

namespace GerenciadorPatrimonios.Domain
{
    public class Marca
    {
        public Marca()
        {
            this.DataInclusao = DateTime.Now;
            this.Ativo = true;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        
        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public Boolean? Ativo { get; set; }

    }
}