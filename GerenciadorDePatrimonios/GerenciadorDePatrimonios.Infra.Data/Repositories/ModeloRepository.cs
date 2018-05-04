using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDePatrimonios.Infra.Data.Repositories
{
    public class ModeloRepository : RepositoryBase<Modelo>, IModeloRepository
    {
        public IEnumerable<Modelo> BuscarPorId(int id)
        {
            return Db.Modelos.Where(m => m.ModeloId == id);
        }

        public List<Modelo> BuscarPorMarcaId(int id)
        {
            return Db.Modelos.Where(m => m.MarcaId == id).ToList();
        }

        public List<Modelo> BuscarPorNome(string nome, int marcaId)
        {
            return Db.Modelos.Where(m => m.Nome == nome && m.MarcaId == marcaId).ToList();
        }
    }
}
