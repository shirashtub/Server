using Serilog;

namespace project.MiddleWares
{
    public class InfoMiddleWare
    {
        private readonly RequestDelegate _next;

        public InfoMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var action = httpContext.GetRouteData().Values["action"]?.ToString();
            Log.Information($"func: {action}");
            await _next(httpContext);
        }
    }
}
