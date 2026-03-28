using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementPortal.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"[LOG] {context.ActionDescriptor.DisplayName} at {DateTime.Now}");
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}