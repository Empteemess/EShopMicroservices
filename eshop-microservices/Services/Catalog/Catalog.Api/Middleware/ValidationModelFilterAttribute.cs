using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.Api.Middleware;

public class ValidationModelFilterAttribute : ActionFilterAttribute, IOrderedFilter
{
    public int Order => -2000;
   
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .SelectMany(
                    kvp => kvp.Value.Errors.Select(e => new ErrorDetails
                    {
                        ErrorType = "Bad Request Error",
                        Message = e.ErrorMessage,
                        Field = kvp.Key
                    })
                ).ToList();

            context.Result = new BadRequestObjectResult(new
            {
                Success = false,
                Errors = errors,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}