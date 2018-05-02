using System;
using System.ComponentModel.DataAnnotations;

namespace LuisCesarMVCWebApi.Models.Entities
{
    public class Patrimonio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é Obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "É permitido 35 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é Obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "É permitido 35 caracteres.")]
        public string Descricao { get; set; }

        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

        public int ModeloId { get; set; }
        public virtual Modelo Modelo { get; set; }

        public string NumeroTombo { get; set; }

        public Patrimonio()
        {
            Id = 0;
            Nome = string.Empty;
            MarcaId = 0;
            ModeloId = 0;
            Descricao = string.Empty;
            NumeroTombo = string.Empty;
        }

    }
}