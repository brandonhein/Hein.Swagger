using Hein.Swagger.Security;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Hein.Swagger.Filters
{
    public class SwaggerSecurityDocumentFilter : IDocumentFilter
    {
        private readonly SecuritySchemeBase _scheme;
        public SwaggerSecurityDocumentFilter(SecuritySchemeBase scheme)
        {
            _scheme = scheme;
        }

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.SecurityDefinitions == null)
            {
                swaggerDoc.SecurityDefinitions = new Dictionary<string, SecurityScheme>();
            }

            swaggerDoc.SecurityDefinitions.Add(_scheme.Name.Replace("-", ""), _scheme);

            if (swaggerDoc.Security == null)
            {
                swaggerDoc.Security = new List<IDictionary<string, IEnumerable<string>>>();
            }

            var securities = new List<IDictionary<string, IEnumerable<string>>>();
            var enforcer = new Dictionary<string, IEnumerable<string>>();
            enforcer.Add(_scheme.Name.Replace("-", ""), new List<string>());
            securities.Add(enforcer);
            foreach (var security in securities)
            {
                swaggerDoc.Security.Add(security);
            }
        }
    }
}
