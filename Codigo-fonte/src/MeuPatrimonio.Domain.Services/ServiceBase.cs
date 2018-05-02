using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Services.Interfaces;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.CrossCutting.Exceptions;

namespace MeuPatrimonio.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        IValidationBase<TEntity> Validation;
        IRepositoryBase<TEntity> Repository;

        public ServiceBase(IValidationBase<TEntity> validation, IRepositoryBase<TEntity> repository)
        {
            Validation = validation;
            Repository = repository;
        }

        public TEntity Add(TEntity entity)
        {
            if (!Validation.IsValid(entity, AcaoEnum.Adicionar))
            {
                throw new ValidacaoException(Validation.GetInvalidMessages());
            }

            return Repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return Repository.GetAll(filter);
        }

        public TEntity GetById(int id)
        {
            var result = Repository.GetById(id);
            return Repository.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            if (!Validation.IsValid(entity, AcaoEnum.Excluir))
            {
                throw new ValidacaoException(Validation.GetInvalidMessages());
            }
            Repository.Remove(entity);
        }

        public void RemoveById(int id)
        {
            var entity = Repository.GetById(id);

            if (!Validation.IsValid(entity, AcaoEnum.Excluir))
            {
                throw new ValidacaoException(Validation.GetInvalidMessages());
            }
            Repository.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            if (!Validation.IsValid(entity, AcaoEnum.Editar))
            {
                throw new ValidacaoException(Validation.GetInvalidMessages());
            }
            return Repository.Update(entity);
        }
    }
}
