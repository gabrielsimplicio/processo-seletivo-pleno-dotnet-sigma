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
            Database.SetInitializer(new GerenciadorPatrimonioDataContextInitializer());
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

            // Objetos string de Classes serao configurados para varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            // Objetos string de Classes serao configurados para ter max length 100
            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PatrimonioConfiguration());
            modelBuilder.Configurations.Add(new MarcaConfiguration());
            modelBuilder.Configurations.Add(new ModeloConfiguration());
        }

        public class GerenciadorPatrimonioDataContextInitializer : DropCreateDatabaseIfModelChanges<GerenciadorDePatrimoniosContext>
        {
            protected override void Seed(GerenciadorDePatrimoniosContext context)
            {
                context.Marcas.Add(new Marca { Nome = "Motorola" });
                context.Marcas.Add(new Marca { Nome = "Samsung" });
                context.Marcas.Add(new Marca { Nome = "Apple" });
                context.SaveChanges();

                context.Modelos.Add(new Modelo { Nome = "Moto X", MarcaId = 1 });
                context.Modelos.Add(new Modelo { Nome = "Moto X2", MarcaId = 1 });
                context.Modelos.Add(new Modelo { Nome = "J7", MarcaId = 2 });
                context.Modelos.Add(new Modelo { Nome = "J5", MarcaId = 2 });
                context.Modelos.Add(new Modelo { Nome = "7 PLUS", MarcaId = 3 });
                context.Modelos.Add(new Modelo { Nome = "X", MarcaId = 3 });
                context.SaveChanges();

                context.Patrimonios.Add(new Patrimonio { Nome = "Celular da Empresa", MarcaId = 1, ModeloId = 1, Descricao = " ", NumeroTombo = new System.Guid() });
                context.Patrimonios.Add(new Patrimonio { Nome = "Celular Pessoal", MarcaId = 2, ModeloId = 2, Descricao = " ", NumeroTombo = new System.Guid() });
                context.Patrimonios.Add(new Patrimonio { Nome = "Celular do Escritorio", MarcaId = 3, ModeloId = 3, Descricao = " ", NumeroTombo = new System.Guid() });
                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
