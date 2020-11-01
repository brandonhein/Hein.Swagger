using Microsoft.OpenApi.Models;

namespace Hein.Swagger.Security.Keys
{
    public class BearerScheme : SecuritySchemeBase
    {
        public BearerScheme(string name, string description = null)
        {
            base.Reference = new OpenApiReference()
            {
                Type = ReferenceType.SecurityScheme,
                Id = name.Replace("-", "")
            };

            base.Name = name;
            base.Description = description;
            base.Type = SecuritySchemeType.Http;
            base.Scheme = "bearer";
            base.BearerFormat = "JWT";
        }
    }
}
