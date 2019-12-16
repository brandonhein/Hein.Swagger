using Hein.Swagger.Security;
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

        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Responses.Add("401", new Response { Description = "Unauthorized" });
            operation.Responses.Add("403", new Response { Description = "Forbidden" });

            var security = new List<Dictionary<string, IEnumerable<string>>>();
            security.Add(new Dictionary<string, IEnumerable<string>>()
            {
                { _scheme.Type, new List<string>() }
            });
        }
    }
}
