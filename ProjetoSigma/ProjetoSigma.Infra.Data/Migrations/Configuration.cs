using System.Data.Entity.Migrations;

namespace ProjetoSigma.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoSigma.Infra.Data.Context.SigmaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
