using ProjetoSigma.Infra.CrossCutting.Validation;

namespace ProjetoSigma.Domain.Entities
{
    public class PatrimonioDomain : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tombo { get; protected set; }
        

        public int ModeloId { get; set; }
        public virtual ModeloDomain Modelo { get; set; }

        public int MarcaId { get; set; }
        public virtual MarcaDomain Marca { get; set; }

        public override void AddValidationError(string erro)
        {
            ValidationResult.Add(erro);
        }

        public override bool Validate()
        {
            ValidationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Nome))
                AddValidationError("O 'Nome' é obrigatório");

            if (ModeloId == 0)
                AddValidationError("O 'Modelo' é obrigatório");

            if (MarcaId == 0)
                AddValidationError("A 'Marca' é obrigatório");

            return ValidationResult.IsValid;
        }
    }
}