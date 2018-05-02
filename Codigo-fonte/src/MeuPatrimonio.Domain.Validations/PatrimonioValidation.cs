using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.Enums;
using MeuPatrimonio.Infra.CrossCutting.Types;

namespace MeuPatrimonio.Domain.Validations
{
    public class PatrimonioValidation : ValidationBase<Patrimonio>, IPatrimonioValidation
    {
        private Patrimonio Entity;

        IMarcaRepository MarcaRepository;
        IModeloRepository ModeloRepository;
        
        public PatrimonioValidation()
        {

        }

        public PatrimonioValidation(IPatrimonioRepository repository, IMarcaRepository marcaRepository, IModeloRepository modeloRepository) : base(repository)
        {
            MarcaRepository = marcaRepository;
            ModeloRepository = modeloRepository;
        }

        private ValidationItem<Patrimonio> AtributoNomeNaoVazio
        {
            get
            {
                return ValidationItem<Patrimonio>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (Patrimonio => !string.IsNullOrEmpty(Patrimonio.Nome)),
                    new Mensagem { Texto = "Nome não pode ser vazio" }
                );
            }
        }

        private ValidationItem<Patrimonio> AtributoMarcaNaoVazio
        {
            get
            {
                return ValidationItem<Patrimonio>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (Patrimonio => Patrimonio.MarcaId > 0),
                    new Mensagem { Texto = "Marca não pode ser vazio" }
                );
            }
        }

        private ValidationItem<Patrimonio> AtributoModeloNaoVazio
        {
            get
            {
                return ValidationItem<Patrimonio>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (Patrimonio => Patrimonio.ModeloId > 0),
                    new Mensagem { Texto = "Modelo não pode ser vazio" }
                );
            }
        }

        private ValidationItem<Patrimonio> AtributoMarcaNaoEncontrada
        {
            get
            {
                return ValidationItem<Patrimonio>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (Patrimonio => MarcaRepository.GetById(Patrimonio.MarcaId) != null),
                    new Mensagem { Texto = "Marca não encontrada" }
                );
            }
        }

        private ValidationItem<Patrimonio> AtributoModeloNaoEncontrado
        {
            get
            {
                return ValidationItem<Patrimonio>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (Patrimonio => ModeloRepository.GetById(Patrimonio.ModeloId) != null),
                    new Mensagem { Texto = "Modelo não encontrado" }
                );
            }
        }

        private ValidationItem<Patrimonio> RegraNomeJaExiste
        {
            get
            {
                return ValidationItem<Patrimonio>.Create
                (
                    Entity,
                    (AcaoEnum.Adicionar | AcaoEnum.Editar),
                    (Patrimonio =>
                        !string.IsNullOrEmpty(Patrimonio.Nome) &&
                        !Repository.Exists(source =>
                            ((Patrimonio.Id > 0 && (source.Id != Patrimonio.Id) && (source.Nome.ToLower() == Patrimonio.Nome.ToLower())) ||
                            (Patrimonio.Id <= 0 && (source.Nome.ToLower() == Patrimonio.Nome.ToLower()))))),
                    new Mensagem { Texto = "Nome do patrimonio já existe" }
                );
            }
        }

        private ValidationItem<Patrimonio> RegraTomboNaoPodeSerAlterado
        {
            get
            {
                var source = Repository.GetById(Entity.Id);

                return ValidationItem<Patrimonio>.Create
                (
                    Entity,
                    (AcaoEnum.Editar),
                    (patrimonio => (source.Id == patrimonio.Id) && (source.Tombo == patrimonio.Tombo)),
                    new Mensagem { Texto = "Tombo não pode ser alterado" }
                );
            }
        }

        public override void CreateAttributeValidations(Patrimonio entity)
        {
            Entity = entity;

            Add(AtributoNomeNaoVazio);
            Add(AtributoMarcaNaoVazio);
            Add(AtributoMarcaNaoEncontrada);
            Add(AtributoModeloNaoVazio);
            Add(AtributoModeloNaoEncontrado);
        }

        public override void CreateBusinessRuleValidations(Patrimonio entity)
        {
            Entity = entity;

            Add(RegraNomeJaExiste);
            Add(RegraTomboNaoPodeSerAlterado);
        }
    }
}
