using MeuPatrimonio.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MeuPatrimonio.Infra.Data.ORM.EntityFramework.Configurations
{
    public class PatrimonioConfiguration : EntityTypeConfiguration<Patrimonio>
    {
        public PatrimonioConfiguration()
        {
            ToTable("PATRIMONIO", "meupatrimonio");

            HasKey(patrimonio => patrimonio.Id);

            Property(patrimonio => patrimonio.Nome)
                .IsRequired()
                .HasMaxLength(30);

            Property(patrimonio => patrimonio.Descricao)
                .IsRequired()
                .HasMaxLength(30);

            Property(patrimonio => patrimonio.Tombo)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            HasRequired(patrimonio => patrimonio.Marca)
                .WithMany(marca => marca.Patrimonios)
                .HasForeignKey(patrimonio => patrimonio.MarcaId);

            HasRequired(patrimonio => patrimonio.Modelo)
                .WithMany(modelo => modelo.Patrimonios)
                .HasForeignKey(patrimonio => patrimonio.ModeloId);
        }
    }
}
