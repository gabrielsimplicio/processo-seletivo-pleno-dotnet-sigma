using System.Collections.Generic;
using System.Linq;

namespace ProjetoSigma.Infra.CrossCutting.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _listaErrors = new List<ValidationError>();

        public IEnumerable<ValidationError> Errors => _listaErrors;
        public bool IsValid => !Errors.Any();

        public void Add(string erro)
        {
            _listaErrors.Add(new ValidationError(erro));
        }
    }
}