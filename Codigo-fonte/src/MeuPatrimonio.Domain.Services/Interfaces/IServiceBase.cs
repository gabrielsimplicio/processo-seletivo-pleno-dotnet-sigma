using System;
using System.Collections.Generic;

namespace MeuPatrimonio.Domain.Services.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter = null);
    }
}
