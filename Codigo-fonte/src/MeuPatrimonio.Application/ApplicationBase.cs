using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.Services.Interfaces;

namespace MeuPatrimonio.Application
{
    public class ApplicationBase<TEntity, TEntityDTO> : IApplicationBase<TEntity, TEntityDTO> where TEntity : class
    {
        public IServiceBase<TEntity> Service;

        public ApplicationBase(IServiceBase<TEntity> service)
        {
            Service = service;
        }

        public TEntityDTO Add(TEntityDTO entityDTO)
        {
            return Mapper.Map<TEntityDTO>(Service.Add(Mapper.Map<TEntity>(entityDTO)));
        }

        public IList<TEntityDTO> GetAll(TEntityDTO filter)
        {
            var lista = Service.GetAll(CreateQueryExpression(filter));

            if (lista != null && lista.Count() > 0)
            {
                return Mapper.Map<IList<TEntityDTO>>(lista);
            }

            return null;
        }

        public virtual Expression<Func<TEntity, bool>> CreateQueryExpression(TEntityDTO filter)
        {
            throw new NotImplementedException();
        }

        public TEntityDTO GetById(int id)
        {
            return Mapper.Map<TEntityDTO>(Service.GetById(id));
        }

        public void Remove(TEntityDTO entityDTO)
        {
            Service.Remove(Mapper.Map<TEntity>(entityDTO));
        }

        public void RemoveById(int id)
        {
            Service.RemoveById(id);
        }

        public virtual TEntityDTO Update(TEntityDTO entityDTO)
        {
            return Mapper.Map<TEntityDTO>(Service.Update(Mapper.Map<TEntity>(entityDTO)));
        }
    }
}
