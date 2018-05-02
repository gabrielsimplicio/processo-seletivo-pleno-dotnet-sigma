using GerenciadorPatrimonios.Data.Mappings;
using GerenciadorPatrimonios.Domain;
using System;
using System.Data.Entity;

namespace GerenciadorPatrimonios.Data.DataContexts
{
    public class GerenciadorPatrimoniosDataContext : DbContext
    {
        public GerenciadorPatrimoniosDataContext() : base("GerenciadorPatrimoniosConnectionString")
        {
            Database.SetInitializer(new GerenciadorPatrimoniosDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ModeloMap());
            modelBuilder.Configurations.Add(new MarcaMap());
            modelBuilder.Configurations.Add(new PatrimonioMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class GerenciadorPatrimoniosDataContextInitializer : DropCreateDatabaseIfModelChanges<GerenciadorPatrimoniosDataContext>
    {
        
        protected override void Seed(GerenciadorPatrimoniosDataContext context)
        {
            context.Marcas.Add(new Marca { Nome = "Dell" });
            context.Marcas.Add(new Marca { Nome = "Lenovo" });
            context.SaveChanges();

            context.Modelos.Add(new Modelo { Nome = "Vostro", MarcaId = 2 });
            context.Modelos.Add(new Modelo { Nome = "Legion", MarcaId = 1 });
            context.SaveChanges();

            context.Patrimonios.Add(new Patrimonio { Nome = "Teste", NumeroTombo = 101, ModeloId = 1 });
            context.Patrimonios.Add(new Patrimonio { Nome = "Teste1", NumeroTombo = 102, ModeloId = 2 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
