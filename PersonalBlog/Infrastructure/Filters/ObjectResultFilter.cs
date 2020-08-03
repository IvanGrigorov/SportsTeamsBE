namespace PersonalBlog.Infrastructure.Filters
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ObjectResultFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result && result.Value == null)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
