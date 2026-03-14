using Microsoft.AspNetCore.Builder;

namespace MiddlewareDemo.Middleware
{
    //This lets you call app.UseCorrelationId(); in Program.cs—much cleaner and more readable.
    public static class CorrelationIdMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationIdMiddleware>();
        }
    }
}
