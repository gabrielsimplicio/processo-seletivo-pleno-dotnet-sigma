using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.CrossCutting.Types;
using System.Collections.Generic;

namespace MeuPatrimonio.Domain.Validations.Interfaces
{
    public interface IValidationBase<TEntity> where TEntity : class
    {
        void CreateAttributeValidations(TEntity entity);
        void CreateBusinessRuleValidations(TEntity entity);
        bool IsValid(TEntity entity, AcaoEnum action);
        IList<Mensagem> GetInvalidMessages();
    }
}
