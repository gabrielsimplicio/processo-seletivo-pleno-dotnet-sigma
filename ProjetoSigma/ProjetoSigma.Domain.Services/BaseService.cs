using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity model)
        {
            return _repository.Add(model);
        }

        public TEntity Update(TEntity model)
        {
            return _repository.Update(model);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}