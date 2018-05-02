namespace ProjetoSigma.Infra.CrossCutting.Validation
{
    public class ValidationError
    {
        public string Error { get; set; }

        public ValidationError(string error)
        {
            Error = error;
        }
    }
}