using AuthMiddlewareApp.Services;

namespace AuthMiddlewareApp.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthService authService)
        {
            var path = context.Request.Path.Value;

            if (path.StartsWith("/Admin"))
            {
                if (!authService.IsAuthenticated(context))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized access to Admin area");
                    return;
                }
            }

            await _next(context);
        }
    }
}