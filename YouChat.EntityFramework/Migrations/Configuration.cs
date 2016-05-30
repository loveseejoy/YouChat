using System.Data.Entity.Migrations;
using YouChat.Migrations.Seed;

namespace YouChat.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.AbpZeroTemplateDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpZeroTemplate";
        }

        protected override void Seed(EntityFramework.AbpZeroTemplateDbContext context)
        {
            new InitialDbBuilder(context).Create();
        }
    }
}
