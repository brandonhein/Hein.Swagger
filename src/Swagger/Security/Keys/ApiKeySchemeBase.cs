using Microsoft.OpenApi.Models;

namespace Hein.Swagger.Security.Keys
{
    public abstract class ApiKeySchemeBase : SecuritySchemeBase
    {
        protected ApiKeySchemeBase(string name, string description = null)
        {
            base.Reference = new OpenApiReference()
            {
                Type = ReferenceType.SecurityScheme,
                Id = name
            };
            base.Name = name;
            base.Description = description;
            base.Type = SecuritySchemeType.ApiKey;
        }
    }
}
