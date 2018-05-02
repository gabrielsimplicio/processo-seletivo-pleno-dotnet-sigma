using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Infra.Data.EntityConfig;

namespace ProjetoSigma.Infra.Data.Context
{
    public class SigmaContext : DbContext
    {
        public SigmaContext() 
            : base("SigmaConnectionString")
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<MarcaDomain> Marcas { get; set; }
        public DbSet<ModeloDomain> Modelos { get; set; }
        public DbSet<PatrimonioDomain> Patrimonios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));
            

            modelBuilder.Configurations.Add(new MarcaConfig());
            modelBuilder.Configurations.Add(new ModeloConfig());
            modelBuilder.Configurations.Add(new PatrimonioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}