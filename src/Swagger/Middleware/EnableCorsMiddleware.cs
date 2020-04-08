using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hein.Swagger.Middleware
{
    public class EnableCorsMiddleware
    {
        private readonly RequestDelegate _next;

        public EnableCorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
                httpContext.Response.Headers.Add("Access-Control-Max-Age", "86400");
                return Task.FromResult(0);
            }, context);

            await _next(context);
        }
    }
}
