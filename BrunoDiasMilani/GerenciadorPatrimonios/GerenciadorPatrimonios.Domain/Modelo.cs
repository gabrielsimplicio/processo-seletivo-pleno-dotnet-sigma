using System;
using System.Collections;
using System.Collections.Generic;

namespace GerenciadorPatrimonios.Domain
{
    public class Modelo
    {
        public Modelo()
        {
            this.DataInclusao = DateTime.Now;
            this.Ativo = true;
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime? DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public Boolean? Ativo { get; set; }

        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }

    }
}