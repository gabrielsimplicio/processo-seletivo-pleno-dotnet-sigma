using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LuisCesarMVCWebApi.Models.Entities
{
    public class Marca
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é Obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "É permitido 35 caracteres.")]
        public string Nome { get; set; }

        public virtual ICollection<Patrimonio> Patrimonios { get; set; }
    }
}