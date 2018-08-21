using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bank.WebAPI.OAuth
{
    public class AccessTokensProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var usuario = BaseUsers
                .Users().FirstOrDefault(x => x.Name == context.UserName && x.Password == context.Password);

            if (usuario == null)
            {
                context.SetError("invalid_grant", "Usuário não encontrado um senha incorreta.");
                return;
            }

            var userIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(userIdentity);
        }
    }
}