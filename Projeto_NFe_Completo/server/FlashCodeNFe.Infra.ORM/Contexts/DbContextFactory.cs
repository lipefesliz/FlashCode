using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace FlashCodeNFe.Infra.ORM.Contexts
{
    /// <summary>
    /// Essa classe resolve o problema do Migration que apresentava erro ao iniciar o FlashCodeNFeDbContext 
    /// quando havia construtor COM parâmetros.
    /// 
    /// Não existe um ponto de chamada para essa classe. 
    /// 
    /// O próprio Migrations procura no Assembly uma classe que implementa IDbContextFactory
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DbContextFactory : IDbContextFactory<FlashCodeNFeDbContext>
    {
        public FlashCodeNFeDbContext Create()
        {
            return new FlashCodeNFeDbContext();
        }
    }
}
