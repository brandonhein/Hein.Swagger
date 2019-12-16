﻿using Hein.Swagger.Middleware;
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
    }
}