namespace AuthMiddlewareApp.Services
{
    public interface IAuthService
    {
        bool IsAuthenticated(HttpContext context);
    }
}