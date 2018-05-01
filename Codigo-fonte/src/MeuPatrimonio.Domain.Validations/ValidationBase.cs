using System.Linq;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Types;
using System.Collections.Generic;

namespace MeuPatrimonio.Domain.Validations
{
    public class ValidationBase<TEntity> : IValidationBase<TEntity> where TEntity : class
    {
        public TEntity Entity;
        public IList<Mensagem> InvalidMessages;
        public IList<ValidationItem<TEntity>> Features;

        public ValidationBase()
        {
        }

        public virtual void CreateAttributeValidations(TEntity entity)
        {
        }

        public virtual void CreateBusinessRuleValidations(TEntity entity)
        {
        }

        public void Add(ValidationItem<TEntity> item)
        {
            if (Features == null)
            {
                Features = new List<ValidationItem<TEntity>>();
            }

            Features.Add(item);
        }

        public virtual bool IsValid(TEntity entity)
        {
            Features = new List<ValidationItem<TEntity>>();
            InvalidMessages = new List<Mensagem>();

            CreateAttributeValidations(entity);
            CreateBusinessRuleValidations(entity);

            if (Features != null && Features.Count > 0)
            {
                Features.ToList().ForEach(feature =>
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
