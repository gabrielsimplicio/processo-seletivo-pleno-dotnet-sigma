using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Services.Interfaces;
using MeuPatrimonio.Domain.Validations.Interfaces;

namespace MeuPatrimonio.Domain.Services
{
    public class MarcaService : ServiceBase<Marca>, IMarcaService
    {
        public MarcaService(IMarcaValidation validation, IMarcaRepository repository) : base(validation, repository)
        {
        }
    }
}
