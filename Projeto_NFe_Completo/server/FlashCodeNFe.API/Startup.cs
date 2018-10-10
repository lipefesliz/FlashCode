using Microsoft.Owin;
using FlashCodeNFe.API.App_Start;
using Owin;
using System.Web.Http;
using System.Diagnostics.CodeAnalysis;

[assembly: OwinStartup(typeof(FlashCodeNFe.API.Startup))]
namespace FlashCodeNFe.API
{
    /// <summary>
    /// Classe para o inicio da API.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Método que invoca as configurações iniciais para execução da API
        /// 
        /// Existem configurações que são executadas durante a inicialização. Veja também em Global.asax 
        /// 
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            // Cria a configuração da api
            HttpConfiguration config = new HttpConfiguration();
            // Inicia a API com as configurações
            app.UseWebApi(config);
        }
    }
}