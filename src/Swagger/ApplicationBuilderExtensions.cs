using Hein.Swagger.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

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

        public static IApplicationBuilder ManipulateSwaggerUI(this IApplicationBuilder app, Action<string> htmlManipulation)
        {
            app.Use(async (context, next) =>
            {
                var newContent = string.Empty;
                var existingBody = context.Response.Body;

                using (var newBody = new MemoryStream())
                {
                    context.Response.Body = newBody;

                    await next();

                    context.Response.Body = existingBody;

                    newBody.Seek(0, SeekOrigin.Begin);
                    newContent = new StreamReader(newBody).ReadToEnd();

                    htmlManipulation(newContent);

                    // Send our modified content to the response body.
                    await context.Response.WriteAsync(newContent);
                }
            });

            return app;
        }
    }
}
