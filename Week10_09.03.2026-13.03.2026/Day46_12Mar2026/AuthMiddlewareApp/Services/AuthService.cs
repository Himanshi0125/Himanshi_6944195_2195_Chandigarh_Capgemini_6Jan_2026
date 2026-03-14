namespace AuthMiddlewareApp.Services
{
    public class AuthService : IAuthService
    {
        public bool IsAuthenticated(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("user"))
            {
                return true;
            }

            return false;
        }
    }
}