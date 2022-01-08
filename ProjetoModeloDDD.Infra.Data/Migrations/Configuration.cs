using System.Data.Entity.Migrations;

namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.ProjetoModeloContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.ProjetoModeloContext context)
        {
            
        }
    }
}
