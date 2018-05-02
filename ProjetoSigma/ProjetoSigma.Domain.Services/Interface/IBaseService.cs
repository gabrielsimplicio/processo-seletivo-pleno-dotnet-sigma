using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjetoSigma.Domain.Services.Interface
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity model);
        TEntity Update(TEntity model);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
    }
}