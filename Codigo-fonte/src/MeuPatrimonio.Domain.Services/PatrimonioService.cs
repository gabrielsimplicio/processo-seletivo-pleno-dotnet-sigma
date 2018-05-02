using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Services.Interfaces;
using MeuPatrimonio.Domain.Validations.Interfaces;

namespace MeuPatrimonio.Domain.Services
{
    public class PatrimonioService : ServiceBase<Patrimonio>, IPatrimonioService
    {
        public PatrimonioService(IPatrimonioValidation validation, IPatrimonioRepository repository) : base(validation, repository)
        {
        }
    }
}
