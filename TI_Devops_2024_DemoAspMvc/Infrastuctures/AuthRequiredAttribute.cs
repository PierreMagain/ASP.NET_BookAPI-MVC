using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TI_Devops_2024_DemoAspMvc.Infrastuctures
{
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {
        }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {

        private readonly SessionManager _session;

        public AuthRequiredFilter(SessionManager session)
        {
            _session = session;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(_session.CurrentUser == null)
            {
                context.Result = new RedirectToRouteResult(new {
                    action = "Login",
                    controller = "User"
                });
            }
        }
    }
}
