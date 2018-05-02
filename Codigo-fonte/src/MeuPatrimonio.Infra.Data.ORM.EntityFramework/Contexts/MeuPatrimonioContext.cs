using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Infra.Data.Interfaces;
using MeuPatrimonio.Infra.Data.ORM.EntityFramework.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace MeuPatrimonio.Infra.Data.ORM.EntityFramework.Contexts
{
    public class MeuPatrimonioContext : DbContext, IDatasourceContext
    {
        public MeuPatrimonioContext() : base("meupatrimonio")
        {
        }

        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.HasDefaultSchema("meupatrimonio");

            modelBuilder.Configurations.Add(new MarcaConfiguration());
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Add(entity);
            SaveChanges();

            return entity;
        }

        public TEntity Find<TEntity>(Func<TEntity, bool> filter = null) where TEntity : class
        {
            return Set<TEntity>().FirstOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsEnumerable();
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }

        public TEntity GetById<TEntity>(int id) where TEntity : class
        {
            return Set<TEntity>().Find(id);
        }
    }
}
