using Microsoft.OpenApi.Models;

namespace Hein.Swagger.Security.Keys
{
    public abstract class ApiKeyBase : SecuritySchemeBase
    {
        protected ApiKeyBase(string name, string description = null)
        {
            base.Reference = new OpenApiReference()
            {
                Type = ReferenceType.SecurityScheme,
                Id = name.Replace("-", "")
            };
            base.Name = name;
            base.Description = description;
            base.Type = SecuritySchemeType.ApiKey;
        }
    }
}
