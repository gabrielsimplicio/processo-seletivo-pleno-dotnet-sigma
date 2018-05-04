using GerenciadorDePatrimonios.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDePatrimonios.API.Models
{
    public class PatrimonioModel
    {
        [Key]
        [Required]
        public int PatrimonioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }
        [Required]
        public int ModeloId { get; set; }
        public virtual Modelo Modelo { get; set; }
        public string Descricao { get; set; }
        public Guid NumeroTombo { get; set; }
    }
}