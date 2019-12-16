using Hein.Swagger.Filters;
using Hein.Swagger.Security.Keys;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hein.Swagger
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void EnforceQueryKey(this SwaggerGenOptions options, string queryName, string description = null)
        {
            var scheme = new QueryStringSecurityScheme(queryName, description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        public static void EnforceHeaderKey(this SwaggerGenOptions options, string headerName, string description = null)
        {
            var scheme = new HeaderSecurityScheme(headerName, description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        public static void EnforceCookieKey(this SwaggerGenOptions options, string cookieName, string description = null)
        {
            var scheme = new CookieSecurityScheme(cookieName, description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        public static void GithubRepository(this SwaggerGenOptions options, string githubRepositoryUrl)
        {
            options.DocumentFilter<GithubRepositoryDocumentFilter>(githubRepositoryUrl);
        }
    }
}
