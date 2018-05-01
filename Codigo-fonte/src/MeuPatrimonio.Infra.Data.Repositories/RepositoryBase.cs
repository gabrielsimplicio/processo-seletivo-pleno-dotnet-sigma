using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(TEntity entity)
        {
            Context.Add(entity);
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter = null)
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

        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }
    }
}
