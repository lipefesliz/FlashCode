using System.Web.Http;
using FlashCodeNFe.Infra.ORM.Contexts;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Diagnostics.CodeAnalysis;
using FlashCodeNFe.Aplicacao.Features.Emitentes;
using FlashCodeNFe.Infra.ORM.Features.Emitentes;
using FlashCodeNFe.Dominio.Features.Emitentes;
using FlashCodeNFe.Aplicacao.Features.Destinatarios;
using FlashCodeNFe.Dominio.Features.Destinatarios;
using FlashCodeNFe.Infra.ORM.Features.Destinatarios;
using FlashCodeNFe.Aplicacao.Features.Transportadores;
using FlashCodeNFe.Dominio.Features.Transportadores;
using FlashCodeNFe.Aplicacao.Features.Produtos;
using FlashCodeNFe.Infra.ORM.Features.Orders;
using FlashCodeNFe.Dominio.Features.Produtos;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais;

namespace FlashCodeNFe.API.IoC
{
    /// <summary>
    /// Classe responsável por realizar as configurações de injeção de depêndencia.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        /// <summary>
        /// Método que inicializa a injeção de depêndencia
        /// </summary>
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterServices(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            // Informa que para resolver as depedências nos construtores será usado o container criado
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }


        /// <summary>
        /// Registra todos os serviços que podem ser injetados nos construtores
        /// </summary>
        /// <param name="container">É o contexto de injeção que deve conter as classes que podem ser injetadas</param>
        public static void RegisterServices(Container container)
        {

            // TODO: Por enquanto estaremos criando o contexto do EF por aqui. Precisaremos trocar por uma Factory
            container.Register<FlashCodeNFeDbContext>(() => new FlashCodeNFeDbContext(), Lifestyle.Scoped);
            container.Register<IEmitenteServico, EmitenteServico>();
            container.Register<IEmitenteRepositorio, EmitenteRepository>();
            container.Register<IDestinatarioServico, DestinatarioServico>();
            container.Register<IDestinatarioRepositorio, DestinatarioRepository>();
            container.Register<ITransportadorServico, TransportadorServico>();
            container.Register<ITransportadorRepositorio, TransportadorRepository>();
            container.Register<IProdutoServico, ProdutoServico>();
            container.Register<IProdutoRepositorio, ProdutoRepository>();
            container.Register<INotaFiscalRepositorio, NotaFiscalRepository>();
            container.Register<INotaFiscalServico, NotaFiscalServico>();
        }
    }
}