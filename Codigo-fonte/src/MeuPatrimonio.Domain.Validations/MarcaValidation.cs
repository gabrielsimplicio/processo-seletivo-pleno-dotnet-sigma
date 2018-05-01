using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Types;

namespace MeuPatrimonio.Domain.Validations
{
    public class MarcaValidation : ValidationBase<Marca>, IMarcaValidation
    {
        public override void CreateAttributeValidations(Marca entity)
        {
            Add(ValidationItem<Marca>.Create(entity, (marca => !string.IsNullOrEmpty(marca.Nome)), new Mensagem { Texto = "Nome não pode ser vazio" }));
        }
    }
}
