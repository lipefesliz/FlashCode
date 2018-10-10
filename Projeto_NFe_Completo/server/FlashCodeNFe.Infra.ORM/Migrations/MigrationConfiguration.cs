using FlashCodeNFe.Infra.ORM.Contexts;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Initializer
{
    /// <summary>
    /// Define as configurações para realização da migração do banco conforme alterações no o
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MigrationConfiguration : DbMigrationsConfiguration<FlashCodeNFeDbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FlashCodeNFeDbContext context)
        {
            // Popula o banco
        }
    }
}
