using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDePatrimonios.API.Models
{
    public class MarcaModel
    {
        [Key]
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual IEnumerable<ModeloModel> Modelos { get; set; }
    }
}