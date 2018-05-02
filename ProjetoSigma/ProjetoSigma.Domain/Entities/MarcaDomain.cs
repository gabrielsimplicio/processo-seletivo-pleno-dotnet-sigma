using ProjetoSigma.Infra.CrossCutting.Validation;

namespace ProjetoSigma.Domain.Entities
{
    public class MarcaDomain : BaseEntity
    {
        public string Nome { get; set; }

        public override void AddValidationError(string erro)
        {
            ValidationResult.Add(erro);
        }

        public override bool Validate()
        {
            ValidationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(Nome))
                AddValidationError("Campo 'Nome' é obrigatório");

            return ValidationResult.IsValid;
        }
    }
}