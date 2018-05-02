using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LuisCesarMVCWebApi.Models.Entities;

namespace LuisCesarMVCWebApi.Models.EntitiesMap
{
    public class ModeloMap : EntityTypeConfiguration<Modelo>
    {
        public ModeloMap()
        {
            ToTable("modelo");
            HasKey(a => a.Id);
            Property(c => c.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Nome).HasColumnName("nome");
        }
    }
}