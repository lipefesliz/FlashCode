using FlashCodeNFe.Infra.ORM.Contexts;
using FlashCodeNFe.Infra.ORM.Migrations;
using System.Data.Entity;

namespace FlashCodeNFe.Infra.ORM.Initializer
{
    /// <summary>
    /// Inicializador do Banco de dados.
    /// 
    /// Essa classe define a estratégia de inicializaçaõ do banco.
    /// </summary>
    public class DbInitializer : MigrateDatabaseToLatestVersion<FlashCodeNFeDbContext, Configuration>
    {
    }
}
