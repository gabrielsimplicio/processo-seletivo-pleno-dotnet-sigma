using System.Data.Entity.ModelConfiguration;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Infra.Data.EntityConfig
{
    public class PatrimonioConfig : EntityTypeConfiguration<PatrimonioDomain>
    {
        public PatrimonioConfig()
        {
            ToTable("Patrimonio");

            HasKey(m => m.Id);

            Property(m => m.Nome).IsRequired();
            Property(m => m.Descricao).IsOptional();
            Property(m => m.Tombo).IsOptional();

            HasRequired(m => m.Marca).WithMany().HasForeignKey(m => m.MarcaId);
            HasRequired(m => m.Modelo).WithMany().HasForeignKey(m => m.ModeloId);

            Ignore(m => m.ValidationResult);
        }
    }
}