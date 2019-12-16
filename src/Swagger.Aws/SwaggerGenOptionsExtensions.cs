using Hein.Swagger.Filters;
using Hein.Swagger.Security.Keys;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hein.Swagger.Aws
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void EnforceAwsApiKey(this SwaggerGenOptions options)
        {
            var scheme = new HeaderSecurityScheme("x-api-key", "AWS API Gateway x-api-key");
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }
    }
}
