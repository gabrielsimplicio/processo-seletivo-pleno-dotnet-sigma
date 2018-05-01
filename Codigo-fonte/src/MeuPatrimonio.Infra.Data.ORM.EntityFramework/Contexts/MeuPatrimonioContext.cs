using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Infra.Data.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace MeuPatrimonio.Infra.Data.ORM.EntityFramework.Contexts
{
    public class MeuPatrimonioContext : DbContext, IDatasourceContext
    {
        public MeuPatrimonioContext() : base("MeuPatrimonioConnectionString")
        {
        }

        public DbSet<Marca> Marcas { get; set; }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Add(entity);
            SaveChanges();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsQueryable();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
