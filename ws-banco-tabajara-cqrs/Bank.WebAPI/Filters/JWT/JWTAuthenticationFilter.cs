using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Bank.WebAPI.Filters.JWT
{
    public class JWTAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            //if (!IsUserAuthorized(filterContext))
            //{
            //    ShowAuthenticationError(filterContext);
            //    return;
            //}
            base.OnAuthorization(filterContext);
        }
    }
}