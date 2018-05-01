using MeuPatrimonio.Infra.CrossCutting.Types;
using System;

namespace MeuPatrimonio.Domain.Validations
{
    public class ValidationItem<TEntity> where TEntity : class
    {
        public TEntity Entity;
        public Mensagem Message { get; set; }
        public Func<TEntity, bool> Rule;

        public static ValidationItem<TEntity> Create(TEntity entity, Func<TEntity, bool> rule, Mensagem message)
        {
            return new ValidationItem<TEntity>
            {
                Entity = entity,
                Message = message,
                Rule = rule
            };
        }

        public bool IsValid()
        {
            return Rule(Entity);
        }
    }
}
