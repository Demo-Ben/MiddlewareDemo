using System.Diagnostics;

namespace MiddlewareDemo.Middleware
{
    public class CorrelationIdMiddleware
    {
        private const string CorrelationIdHeader = "X-Correlation-ID";
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // entry point
        public async Task InvokeAsync(HttpContext context)
        {
            // 1. Read existing correlation ID or create a new one
            if (!context.Request.Headers.TryGetValue(CorrelationIdHeader, out var correlationId))
            {
                correlationId = Activity.Current?.Id ?? Guid.NewGuid().ToString();
                context.Request.Headers[CorrelationIdHeader] = correlationId;
            }

            // 2. Add correlation ID to the response so clients can see it
            context.Response.OnStarting(() =>
            {
                context.Response.Headers[CorrelationIdHeader] = correlationId.ToString();
                return Task.CompletedTask;
            });

            // 3. Log something using the correlation ID
            Console.WriteLine($"[{correlationId}] Incoming request: {context.Request.Method} {context.Request.Path}");

            // 4. Call the next middleware in the pipeline continues
            await _next(context);

            // 5. Optionally log after the rest of the pipeline
            Console.WriteLine($"[{correlationId}] Outgoing response: {context.Response.StatusCode}");
        }
    }
}
