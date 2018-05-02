using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.CrossCutting.Types;

namespace MeuPatrimonio.Domain.Validations
{
    public class ModeloValidation : ValidationBase<Modelo>, IModeloValidation
    {
        private Modelo Entity;

        IMarcaRepository MarcaRepository;

        public ModeloValidation()
        {

        }

        public ModeloValidation(IModeloRepository repository, IMarcaRepository marcaRepository) : base(repository)
        {
            MarcaRepository = marcaRepository;
        }

        private ValidationItem<Modelo> AtributoNomeNaoVazio
        {
            get
            {
                return ValidationItem<Modelo>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (modelo => !string.IsNullOrEmpty(modelo.Nome)),
                    new Mensagem { Texto = "Nome não pode ser vazio" }
                );
            }
        }

        private ValidationItem<Modelo> AtributoMarcaNaoVazio
        {
            get
            {
                return ValidationItem<Modelo>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (modelo => modelo.MarcaId > 0),
                    new Mensagem { Texto = "Marca não pode ser vazio" }
                );
            }
        }

        private ValidationItem<Modelo> AtributoMarcaNaoEncontrada
        {
            get
            {
                return ValidationItem<Modelo>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (modelo => MarcaRepository.GetById(modelo.MarcaId) != null),
                    new Mensagem { Texto = "Marca não encontrada" }
                );
            }
        }

        private ValidationItem<Modelo> RegraNomeJaExiste
        {
            get
            {
                return ValidationItem<Modelo>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (modelo =>
                        !string.IsNullOrEmpty(modelo.Nome) &&
                        !Repository.Exists(source =>
                            ((modelo.Id > 0 && (source.Id != modelo.Id) && (source.Nome.ToLower() == modelo.Nome.ToLower())) ||
                            (modelo.Id <= 0 && (source.Nome.ToLower() == modelo.Nome.ToLower()))) && (source.MarcaId == modelo.MarcaId))),
                    new Mensagem { Texto = "Nome da Modelo já existe" }
                );
            }
        }

        public override void CreateAttributeValidations(Modelo entity)
        {
            Entity = entity;

            Add(AtributoNomeNaoVazio);
            Add(AtributoMarcaNaoVazio);
            Add(AtributoMarcaNaoEncontrada);
        }

        public override void CreateBusinessRuleValidations(Modelo entity)
        {
            Entity = entity;

            Add(RegraNomeJaExiste);
        }
    }
}
