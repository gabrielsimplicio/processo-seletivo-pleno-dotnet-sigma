using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.CrossCutting.Types;
using System;

namespace MeuPatrimonio.Domain.Validations
{
    public class ValidationItem<TEntity> where TEntity : class
    {
        public TEntity Entity;
        public Mensagem Message { get; set; }
        public Func<TEntity, bool> Rule;
        public AcaoEnum Action;

        public static ValidationItem<TEntity> Create(TEntity entity, AcaoEnum action, Func<TEntity, bool> rule, Mensagem message)
        {
            return new ValidationItem<TEntity>
            {
                Entity = entity,
                Message = message,
                Rule = rule,
                Action = action
            };
        }

        public bool IsValid()
        {
            return Rule(Entity);
        }
    }
}
