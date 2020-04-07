using Hein.Swagger.Security;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

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
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

            //var security = new List<Dictionary<string, IEnumerable<string>>>();
            //security.Add(new Dictionary<string, IEnumerable<string>>()
            //{
            //    { _scheme.Type, new List<string>() }
            //});
        }
    }
}
