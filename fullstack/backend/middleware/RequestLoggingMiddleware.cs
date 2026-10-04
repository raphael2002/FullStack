using System.Diagnostics;

namespace InventoryHub.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            await _next(context);
            sw.Stop();

            Console.WriteLine(
                $"[{DateTime.UtcNow}] {context.Request.Method} {context.Request.Path} " +
                $"Status: {context.Response.StatusCode} Duration: {sw.ElapsedMilliseconds} ms");
        }
    }
}
