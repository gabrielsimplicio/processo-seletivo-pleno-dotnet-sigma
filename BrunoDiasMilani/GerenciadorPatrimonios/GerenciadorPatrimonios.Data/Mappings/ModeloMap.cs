using GerenciadorPatrimonios.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPatrimonios.Data.Mappings
{
    class ModeloMap : EntityTypeConfiguration<Modelo>
    {
        public ModeloMap()
        {
            ToTable("Modelo");

            HasKey(a => a.Id);

            Property(a => a.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index",
            new IndexAnnotation(new[]
                {
                    new IndexAttribute("ModeloNomeIndex") { IsUnique = true }
                }));

            Property(a => a.Ativo).IsOptional();

            HasRequired(a => a.Marca);
        }
    }
}
