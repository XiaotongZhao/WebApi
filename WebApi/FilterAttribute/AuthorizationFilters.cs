using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.FilterAttribute
{
    public class AuthorizationFilters : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}
