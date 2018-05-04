namespace GerenciadorDePatrimonios.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.GerenciadorDePatrimoniosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(Contexto.GerenciadorDePatrimoniosContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data.
        //}
    }
}
