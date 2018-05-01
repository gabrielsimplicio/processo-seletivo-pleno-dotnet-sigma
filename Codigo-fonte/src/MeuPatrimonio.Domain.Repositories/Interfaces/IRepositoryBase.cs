using System;
using System.Collections.Generic;

namespace MeuPatrimonio.Domain.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter = null);
    }
}
