using Microsoft.OpenApi.Models;

namespace Hein.Swagger.Security.Keys
{
    public abstract class ApiKeySchemeBase : SecuritySchemeBase
    {
        protected ApiKeySchemeBase(string name, string description = null)
        {
            base.Name = name;
            base.Description = description;
            base.Type = SecuritySchemeType.ApiKey;
        }

        public ParameterLocation In { get; set; }
    }
}
