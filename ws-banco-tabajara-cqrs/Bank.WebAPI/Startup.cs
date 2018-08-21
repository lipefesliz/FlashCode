using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using Bank.WebAPI.OAuth;

[assembly: OwinStartup(typeof(Bank.WebAPI.Startup))]
namespace Bank.WebAPI
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // configuracao WebApi
            var config = new HttpConfiguration();

            // ativando cors
            app.UseCors(CorsOptions.AllowAll);

            // ativando tokens de acesso
            ActivateAccessTokens(app);

            // ativando configuração WebApi
            app.UseWebApi(config);
        }

        private void ActivateAccessTokens(IAppBuilder app)
        {
            var tokenOptionsConfiguration = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new AccessTokensProvider(),
            };

            app.UseOAuthAuthorizationServer(tokenOptionsConfiguration);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}