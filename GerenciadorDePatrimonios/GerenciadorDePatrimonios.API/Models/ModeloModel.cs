using GerenciadorDePatrimonios.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDePatrimonios.API.Models
{
    public class ModeloModel
    {
        [Key]
        public int ModeloId { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public virtual MarcaModel Marca { get; set; }
    }
}