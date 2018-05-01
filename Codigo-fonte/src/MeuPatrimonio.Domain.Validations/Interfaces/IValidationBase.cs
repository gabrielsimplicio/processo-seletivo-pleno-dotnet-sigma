namespace MeuPatrimonio.Domain.Validations.Interfaces
{
    public interface IValidationBase<TEntity> where TEntity : class
    {
        void CreateAttributeValidations(TEntity entity);
        void CreateBusinessRuleValidations(TEntity entity);
        bool IsValid(TEntity entity);
    }
}
