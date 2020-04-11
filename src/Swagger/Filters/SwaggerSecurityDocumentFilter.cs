using Hein.Swagger.Security;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerSecurityDocumentFilter : IDocumentFilter
    {
        private readonly SecuritySchemeBase _scheme;
        public SwaggerSecurityDocumentFilter(SecuritySchemeBase scheme)
        {
            _scheme = scheme;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.SecurityRequirements = new List<OpenApiSecurityRequirement>();

            var requirement = new OpenApiSecurityRequirement()
            {
                [_scheme] = new List<string>()
            };

            if (!swaggerDoc.SecurityRequirements.Any(x => x.Equals(requirement)))
            {
                swaggerDoc.SecurityRequirements.Add(requirement);
            }

            if (swaggerDoc.Components == null)
            {
                swaggerDoc.Components = new OpenApiComponents();
            }

            if (swaggerDoc.Components.SecuritySchemes == null)
            {
                swaggerDoc.Components.SecuritySchemes = new Dictionary<string, OpenApiSecurityScheme>();
            }

            if (!swaggerDoc.Components.SecuritySchemes.ContainsKey(_scheme.Name.Replace("-", "")))
            {
                swaggerDoc.Components.SecuritySchemes.Add(_scheme.Name.Replace("-", ""), _scheme);
            }
        }
    }
}
