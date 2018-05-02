using ProjetoSigma.Infra.CrossCutting.Validation;

namespace ProjetoSigma.Application
{
    public class BaseEntityApp
    {
        public int Id { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}