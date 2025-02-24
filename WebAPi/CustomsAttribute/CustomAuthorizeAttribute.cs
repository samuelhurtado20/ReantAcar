using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPi.CustomsAttribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class CustomAuthorizeAttribute(string permission) : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _permission = permission;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity!.IsAuthenticated)
        {
            // it isn't needed to set unauthorized result
            // as the base class already requires the user to be authenticated
            // this also makes redirect to a login page work properly
            // context.Result = new UnauthorizedResult();
            return;
        }

        // you can also use registered services
        //var someService = context.HttpContext.RequestServices.GetService<ISomeService>();

        var isAuthorized = user.HasClaim(x => x.Value.Equals(_permission, StringComparison.CurrentCultureIgnoreCase) && x.Type == System.Security.Claims.ClaimTypes.Role);
        if (!isAuthorized)
        {
            context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
            return;
        }
    }
}