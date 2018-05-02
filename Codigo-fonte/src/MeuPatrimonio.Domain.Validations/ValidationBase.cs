using System.Linq;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Types;
using System.Collections.Generic;
using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.Data.Repositories;
using MeuPatrimonio.Domain.Repositories.Interfaces;

namespace MeuPatrimonio.Domain.Validations
{
    public class ValidationBase<TEntity> : IValidationBase<TEntity> where TEntity : class
    {
        public TEntity Entity;
        public IList<Mensagem> InvalidMessages;
        public IList<ValidationItem<TEntity>> Itens;
        public IRepositoryBase<TEntity> Repository;

        public ValidationBase()
        {
        }

        public ValidationBase(IRepositoryBase<TEntity> repository)
        {
            Repository = repository;
        }

        public void Add(ValidationItem<TEntity> item)
        {
            if (Itens == null)
            {
                Itens = new List<ValidationItem<TEntity>>();
            }

            Itens.Add(item);
        }

        public virtual void CreateAttributeValidations(TEntity entity)
        {
        }

        public virtual void CreateBusinessRuleValidations(TEntity entity)
        {
        }

        public IList<Mensagem> GetInvalidMessages()
        {
            return InvalidMessages;
        }

        public virtual bool IsValid(TEntity entity, AcaoEnum action)
        {
            Itens = new List<ValidationItem<TEntity>>();
            InvalidMessages = new List<Mensagem>();

            CreateAttributeValidations(entity);
            CreateBusinessRuleValidations(entity);

            Itens = Itens.Where(f => (f.Action & action) > 0).ToList();

            if (Itens != null && Itens.Count > 0)
            {
                Itens.ToList().ForEach(feature =>
                {
                    if (!feature.IsValid())
                    {
                        InvalidMessages.Add(feature.Message);
                    }
                });
            }

            return InvalidMessages.Count <= 0;
        }
    }
}
