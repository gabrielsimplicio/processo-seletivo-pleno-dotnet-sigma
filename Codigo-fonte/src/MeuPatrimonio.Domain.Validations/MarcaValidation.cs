using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.CrossCutting.Types;

namespace MeuPatrimonio.Domain.Validations
{
    public class MarcaValidation : ValidationBase<Marca>, IMarcaValidation
    {
        private Marca Entity;

        public MarcaValidation()
        {

        }

        public MarcaValidation(IMarcaRepository repository) : base(repository)
        {
        }

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

        private ValidationItem<Marca> RegraNomeJaExiste
        {
            get
            {
                return ValidationItem<Marca>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (marca => 
                        !string.IsNullOrEmpty(marca.Nome) && 
                        !Repository.Exists(source => 
                            (marca.Id > 0 && source.Id != marca.Id && source.Nome.ToLower() == marca.Nome.ToLower()) || 
                            (marca.Id <= 0 && source.Nome.ToLower() == marca.Nome.ToLower()))),
                    new Mensagem { Texto = "Nome da marca já existe" }
                );
            }
        }

        public override void CreateAttributeValidations(Marca entity)
        {
            Entity = entity;

            Add(AtributoNomeNaoVazio);
        }

        public override void CreateBusinessRuleValidations(Marca entity)
        {
            Entity = entity;

            Add(RegraNomeJaExiste);
        }
    }
}
