using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDePatrimonios.Infra.Data.Repositories
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public IEnumerable<Marca> BuscarPorId(int id)
        {
            return Db.Marcas.Where(m => m.MarcaId == id);
        }

        public List<Marca> BuscarPorNome(string nome)
        {
            return Db.Marcas.Where(m => m.Nome == nome).ToList();
        }
    }
}
