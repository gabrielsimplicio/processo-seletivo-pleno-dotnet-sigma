using GerenciadorDePatrimonios.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorDePatrimonios.Infra.Data.EntityConfig
{
    public class PatrimonioConfiguration : EntityTypeConfiguration<Patrimonio>
    {
        public PatrimonioConfiguration()
        {
            HasKey(p => new { p.PatrimonioId, p.NumeroTombo });

            Property(x => x.PatrimonioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NumeroTombo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .IsRequired();

            Property(p => p.Descricao)
                .HasMaxLength(255);
        }
    }
}