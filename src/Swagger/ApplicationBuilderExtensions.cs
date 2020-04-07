using Hein.Swagger.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Hein.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder EnableCors(this IApplicationBuilder app)
        {
            return app.UseMiddleware<EnableCorsMiddleware>();
        }

        public static IApplicationBuilder UseCors(this IApplicationBuilder app)
        {
            return app.UseMiddleware<EnableCorsMiddleware>();
        }

        public static IApplicationBuilder UseXResponseTime(this IApplicationBuilder app)
        {
            return app.UseMiddleware<XResponseTimeMiddleware>();
        }

        public static IApplicationBuilder UseResponseTiming(this IApplicationBuilder app)
        {
            return app.UseMiddleware<XResponseTimeMiddleware>();
        }

        public static IApplicationBuilder EnableResponseTiming(this IApplicationBuilder app)
        {
            return app.UseMiddleware<XResponseTimeMiddleware>();
        }

        public static IApplicationBuilder UseLegacySwagger(this IApplicationBuilder app)
        {
            return app.UseSwagger(c => c.SerializeAsV2 = true);
        }
    }
}
