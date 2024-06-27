using Hein.Swagger.Security;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hein.Swagger.Filters
{
    public class SwaggerSecurityOperationalFilter : IOperationFilter
    {
        private readonly SecuritySchemeBase _scheme;
        public SwaggerSecurityOperationalFilter(SecuritySchemeBase scheme)
        {
            _scheme = scheme;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!operation.Responses.ContainsKey("401"))
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

            if (!operation.Responses.ContainsKey("403"))
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });
        }
    }
}
