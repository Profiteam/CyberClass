using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using Utils;

namespace Beauty.Filter
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                context.ExceptionHandled = true;
            }

            if (context.Exception is ServiceErrorException exception)
            {
                context.Result = new BadRequestObjectResult(ErrorHelper.GetError(exception.ErrorNumber));
                context.ExceptionHandled = true;
            }
        }
    }

}
