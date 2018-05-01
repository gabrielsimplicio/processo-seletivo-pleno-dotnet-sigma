using MeuPatrimonio.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MeuPatrimonio.Infra.Data.ORM.EntityFramework.Configurations
{
    public class MarcaConfiguration : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguration()
        {
            HasKey(marca => marca.Id);

            Property(marca => marca.Nome)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
