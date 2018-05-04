using GerenciadorDePatrimonios.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorDePatrimonios.Infra.Data.EntityConfig
{
    public class ModeloConfiguration : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfiguration()
        {
            HasKey(m => m.ModeloId);

            Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(m => m.Marca)
                .WithMany()
                .HasForeignKey(m => m.MarcaId);
        }
    }
}