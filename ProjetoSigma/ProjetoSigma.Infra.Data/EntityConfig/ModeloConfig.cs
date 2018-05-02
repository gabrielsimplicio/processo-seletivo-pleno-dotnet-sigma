using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Infra.Data.EntityConfig
{
    public class ModeloConfig : EntityTypeConfiguration<ModeloDomain>
    {
        public ModeloConfig()
        {
            ToTable("Modelo");

            HasKey(m => m.Id);

            Property(m => m.Nome).IsRequired().HasColumnAnnotation("Index", 
                new IndexAnnotation(
                    new IndexAttribute("IX_Nome") { IsUnique = true})
                );
            
            Ignore(m => m.ValidationResult);
        }
    }
}