﻿using FlashCodeNFe.API.App_Start;
using FlashCodeNFe.API.IoC;
using FlashCodeNFe.Aplicacao.Mapping;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace FlashCodeNFe.API
{
    /// <summary>
    /// Classe para execução de rotinas durante o ciclo de vida da API
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        ///Método de execução de rotinas durante a inicialização da API
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            // Realiza as configurações gerais da API
            GlobalConfiguration.Configure(WebApiConfig.Register);
            SimpleInjectorContainer.Initialize();
            AutoMapperInitializer.Initialize();
        }
    }
}