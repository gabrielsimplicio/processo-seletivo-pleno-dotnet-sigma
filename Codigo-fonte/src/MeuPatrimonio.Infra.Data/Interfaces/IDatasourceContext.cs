using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuPatrimonio.Infra.Data.Interfaces
{
    public interface IDatasourceContext
    {
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
        TEntity Find<TEntity>(Func<TEntity, bool> filter = null) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        TEntity GetById<TEntity>(int id) where TEntity : class;
    }
}
