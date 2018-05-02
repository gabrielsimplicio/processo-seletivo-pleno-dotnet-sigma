using ProjetoSigma.Infra.CrossCutting.Validation;

namespace ProjetoSigma.Infra.CrossCutting.Interfaces
{
    public interface IValidation
    {
        ValidationResult ValidationResult { get; set; }
    }
}