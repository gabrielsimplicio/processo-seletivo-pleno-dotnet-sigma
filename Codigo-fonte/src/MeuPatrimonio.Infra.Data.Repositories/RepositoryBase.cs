using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Infra.Data.Interfaces;

namespace MeuPatrimonio.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private IDatasourceContext Context;

        public RepositoryBase(IDatasourceContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            return Context.Add(entity);
        }

        public bool Exists(Func<TEntity, bool> filter = null)
        {
            return Context.Query<TEntity>().Count(filter) > 0;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return Context.Query<TEntity>();
            }

            return Context.Query<TEntity>().Where(filter);
        }

        public TEntity GetById(int id)
        {
            return Context.Find<TEntity>(c => c.GetType().GetProperty("Id").GetValue(c) == (id as object));
        }

        public void Remove(TEntity entity)
        {
            Context.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return Context.Update(entity);
        }
    }
}
