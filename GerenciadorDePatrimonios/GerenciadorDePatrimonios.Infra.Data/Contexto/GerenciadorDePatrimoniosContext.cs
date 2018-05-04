using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GerenciadorDePatrimonios.Infra.Data.Contexto
{
    public class GerenciadorDePatrimoniosContext : DbContext
    {
        public GerenciadorDePatrimoniosContext()
            : base("GerenciadorPatrimonioConnectionString")
        {

        }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove criação de tabelas no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Remove comando delete em cascata um para muitos
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // Remove comando delete em cascata muitos para muitos
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //// Propriedades de Classe que possuirem Id no nome, exemplo PatrimonioId, sera considerada como chave primaria
            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //    .Configure(p => p.IsKey());

            // Objetos string de Classes serao configurados para varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            // Objetos string de Classes serao configurados para ter max length 100
            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PatrimonioConfiguration());
            modelBuilder.Configurations.Add(new MarcaConfiguration());
            modelBuilder.Configurations.Add(new ModeloConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
