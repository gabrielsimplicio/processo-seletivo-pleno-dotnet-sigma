using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using GerenciadorDePatrimonios.Domain.Repositories;
using GerenciadorDePatrimonios.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDePatrimonios.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected GerenciadorDePatrimoniosContext Db = new GerenciadorDePatrimoniosContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
