using System;
using System.Collections.Generic;
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

        public IEnumerable<TEntityDTO> GetAll(Func<TEntityDTO, bool> filter = null)
        {
            return Mapper.Map<IEnumerable<TEntityDTO>>(Service.GetAll(Mapper.Map<Func<TEntity, bool>>(filter)));
        }

        public TEntityDTO GetById(int id)
        {
            return Mapper.Map<TEntityDTO>(Service.GetById(id));
        }

        public void Remove(TEntityDTO entityDTO)
        {
            Service.Remove(Mapper.Map<TEntity>(entityDTO));
        }

        public TEntityDTO Update(TEntityDTO entityDTO)
        {
            return Mapper.Map<TEntityDTO>(Service.Update(Mapper.Map<TEntity>(entityDTO)));
        }
    }
}
