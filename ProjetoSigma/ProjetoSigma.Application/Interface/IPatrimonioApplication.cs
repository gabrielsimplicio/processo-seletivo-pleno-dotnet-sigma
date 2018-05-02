using System.Collections.Generic;
using ProjetoSigma.Application.ViewModel;

namespace ProjetoSigma.Application.Interface
{
    public interface IPatrimonioApplication : IBaseApplication<PatrimonioViewModel>
    {
        IEnumerable<PatrimonioViewModel> GetPatrimonioByMarca(int marcaId);
        IEnumerable<PatrimonioViewModel> GetPatrimonioByModelo(int modeloId);
    }
}