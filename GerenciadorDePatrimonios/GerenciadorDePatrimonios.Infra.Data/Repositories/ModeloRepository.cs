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
        public bool Exists<Modelo>(string nome, int marcaId)
        {
            return Db.Marcas.Local.Any(m => m.Nome == nome && m.MarcaId == marcaId);
        }
    }
}
