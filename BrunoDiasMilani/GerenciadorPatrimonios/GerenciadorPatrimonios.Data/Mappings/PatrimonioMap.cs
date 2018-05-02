using GerenciadorPatrimonios.Domain;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorPatrimonios.Data.Mappings
{
    class PatrimonioMap : EntityTypeConfiguration<Patrimonio>
    {
        public PatrimonioMap()
        {
            ToTable("Patrimonio");

            HasKey(a => a.Id);
            
            Property(a => a.Nome).HasMaxLength(100).IsRequired();
            Property(a => a.Descricao).HasMaxLength(255);
            
            HasRequired(a => a.Modelo);
                        
        }
    }
}
