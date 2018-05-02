using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MeuPatrimonio.Domain.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        void RemoveById(int id);
        TEntity Update(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        bool Exists(Func<TEntity, bool> filter = null);
    }
}
