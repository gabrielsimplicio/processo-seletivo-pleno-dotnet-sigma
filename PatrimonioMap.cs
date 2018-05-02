using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LuisCesarMVCWebApi.Models.Entities;

namespace LuisCesarMVCWebApi.Models.EntitiesMap
{
    public class PatrimonioMap: EntityTypeConfiguration<Patrimonio>
    {
        public PatrimonioMap()
        {
            ToTable("patrimonio");
            HasKey(a => a.Id);
            Property(c => c.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Nome).HasColumnName("nome");
            Property(a => a.Descricao).HasColumnName("descricao");
            Property(a => a.NumeroTombo).HasColumnName("numero_tombo");

            Property(c => c.MarcaId).HasColumnName("marca_id");
            HasRequired(c => c.Marca).WithMany(b => b.Patrimonios).HasForeignKey(b => b.MarcaId);

            Property(c => c.ModeloId).HasColumnName("modelo_id");
            HasRequired(c => c.Modelo).WithMany(b => b.Patrimonios).HasForeignKey(b => b.ModeloId);

        }
    }
}