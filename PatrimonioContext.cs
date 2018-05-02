using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LuisCesarMVCWebApi.Models.Entities;
using LuisCesarMVCWebApi.Models.EntitiesMap;

namespace LuisCesarMVCWebApi.DbContext
{
    public class PatrimonioContext : System.Data.Entity.DbContext
    {
        public PatrimonioContext()
            : base("DbConnectionString")
        {
            ////Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<PatrimonioContext>(null);

            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Mapeamento das Entidades
            modelBuilder.Configurations.Add(new MarcaMap());
            modelBuilder.Configurations.Add(new ModeloMap());
            modelBuilder.Configurations.Add(new PatrimonioMap());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}