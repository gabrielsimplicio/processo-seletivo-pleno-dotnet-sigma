using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDePatrimonios.Infra.Data.Repositories
{
    public class PatrimonioRepository : RepositoryBase<Patrimonio>, IPatrimonioRepository
    {
        public IEnumerable<Patrimonio> BuscarPorId(int id)
        {
            return Db.Patrimonios.Where(m => m.PatrimonioId == id);
        }

        public IEnumerable<Patrimonio> BuscarPorMarcaId(int id)
        {
            return Db.Patrimonios.Where(m => m.MarcaId == id).ToList();
        }

        public IEnumerable<Patrimonio> BuscarPorModelo(int id)
        {
            return Db.Patrimonios.Where(m => m.ModeloId == id);
        }
    }
}
