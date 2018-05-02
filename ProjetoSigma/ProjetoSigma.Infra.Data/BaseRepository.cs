using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ProjetoSigma.Infra.Data.Context;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Infra.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SigmaContext _sigmaContext;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(SigmaContext sigmaContext)
        {
            _sigmaContext = sigmaContext;
            _dbSet = _sigmaContext.Set<TEntity>();
        }

        public TEntity Add(TEntity model)
        {
            model = _dbSet.Add(model);
            return model;
        }

        public TEntity Update(TEntity model)
        {
            _sigmaContext.Entry(model).State = EntityState.Modified;
            return model;
        }

        public void Delete(int id)
        {
            var model = GetById(id);
            _dbSet.Remove(model);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = _dbSet;
            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet;
            return query.Where(predicate).ToList();
        }

        public void Dispose()
        {
            _sigmaContext.Dispose();
        }
    }
}