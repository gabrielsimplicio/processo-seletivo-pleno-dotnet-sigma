using GerenciadorPatrimonios.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPatrimonios.Data.Mappings
{
    class MarcaMap : EntityTypeConfiguration<Marca>
    {
        public MarcaMap()
        {
            ToTable("Marca");

            HasKey(a => a.Id);

            Property(a => a.Nome).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index",
            new IndexAnnotation(new[]
                {
                    new IndexAttribute("MarcaNomeIndex") { IsUnique = true }
                }));

        }

    }
}
