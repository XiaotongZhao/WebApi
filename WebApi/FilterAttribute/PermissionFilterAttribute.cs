using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.FilterAttribute
{
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }
    }
}
