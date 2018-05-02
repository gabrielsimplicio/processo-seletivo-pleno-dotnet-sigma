using MeuPatrimonio.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MeuPatrimonio.Infra.Data.ORM.EntityFramework.Configurations
{
    public class ModeloConfiguration : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfiguration()
        {
            ToTable("MODELO", "meupatrimonio");

            HasKey(modelo => modelo.Id);

            Property(modelo => modelo.Nome)
                .IsRequired()
                .HasMaxLength(30);

            HasRequired(modelo => modelo.Marca)
                .WithMany(marca => marca.Modelos)
                .HasForeignKey(modelo => modelo.MarcaId);
        }
    }
}
