using GerenciadorDePatrimonios.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorDePatrimonios.Infra.Data.EntityConfig
{
    public class MarcaConfiguration : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguration()
        {
            HasKey(m => m.MarcaId);

            Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(150);

        }
    }
}