using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductManagementFiltersApp.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("Exception captured by CustomExceptionFilter");
            Console.WriteLine(context.Exception.Message);

            context.Result = new ContentResult
            {
                Content = "Oops! Something went wrong. Please contact support.",
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}