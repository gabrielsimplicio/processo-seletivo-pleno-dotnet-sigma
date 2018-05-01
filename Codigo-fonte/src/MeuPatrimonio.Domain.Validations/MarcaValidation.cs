using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.CrossCutting.Types;

namespace MeuPatrimonio.Domain.Validations
{
    public class MarcaValidation : ValidationBase<Marca>, IMarcaValidation
    {
        private Marca Entity;

        private ValidationItem<Marca> AtributoNomeNaoVazio
        {
            get
            {
                return ValidationItem<Marca>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (marca => !string.IsNullOrEmpty(marca.Nome)), 
                    new Mensagem { Texto = "Nome não pode ser vazio" }
                );
            }
        }

        public override void CreateAttributeValidations(Marca entity)
        {
            Entity = entity;

            Add(AtributoNomeNaoVazio);
        }
    }
}
