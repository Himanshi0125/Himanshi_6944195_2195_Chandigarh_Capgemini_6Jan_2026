using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductManagementFiltersApp.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"[LOG] Executing: {context.ActionDescriptor.DisplayName} at {DateTime.Now}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"[LOG] Executed: {context.ActionDescriptor.DisplayName} at {DateTime.Now}");
        }
    }
}