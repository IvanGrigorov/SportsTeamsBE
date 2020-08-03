namespace PersonalBlog.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using PersonalBlog.Infrastructure.Enums;
    using PersonalBlog.Infrastructure.Extensions;

    public class IsAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;
            var role = user.GetUserRole();
            if (role != UserRole.Admin)
            {
                context.Result = new UnauthorizedResult();
            }
            base.OnActionExecuting(context);
        }
    }
}
