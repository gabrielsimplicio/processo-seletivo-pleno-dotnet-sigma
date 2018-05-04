using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Application.Interface
{
    public interface IPatrimonioAppService : IAppServiceBase<Patrimonio>
    {
        IEnumerable<Patrimonio> BuscarPorId(int id);
        IEnumerable<Patrimonio> BuscarPorMarcaId(int id);
        IEnumerable<Patrimonio> BuscarPorModelo(int modeloId);
    }
}
