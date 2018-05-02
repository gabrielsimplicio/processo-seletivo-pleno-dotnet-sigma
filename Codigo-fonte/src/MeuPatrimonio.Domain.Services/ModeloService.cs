using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Services.Interfaces;
using MeuPatrimonio.Domain.Validations.Interfaces;

namespace MeuPatrimonio.Domain.Services
{
    public class ModeloService : ServiceBase<Modelo>, IModeloService
    {
        public ModeloService(IModeloValidation validation, IModeloRepository repository) : base(validation, repository)
        {
        }
    }
}
