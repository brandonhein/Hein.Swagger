using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Hein.Swagger.Middleware
{
    public class XResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;
        public XResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();

            context.Response.OnStarting(() => {
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;

                context.Response.Headers["X-Response-Time"] = responseTimeForCompleteRequest.ToString();
                return Task.CompletedTask;
            });

            return _next(context);

        }
    }
}
