using ProjetoSigma.Infra.CrossCutting.Interfaces;
using ProjetoSigma.Infra.CrossCutting.Validation;

namespace ProjetoSigma.Domain
{
    public abstract class BaseEntity : IValidation
    {
        public int Id { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public abstract void AddValidationError(string erro);
        public abstract bool Validate();
    }
}