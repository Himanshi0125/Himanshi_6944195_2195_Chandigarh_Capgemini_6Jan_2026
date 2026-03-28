using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementPortal.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = "Error occurred. Please try again.",
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}