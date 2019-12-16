using Swashbuckle.AspNetCore.Swagger;

namespace Hein.Swagger.Security
{
    public abstract class SecuritySchemeBase : SecurityScheme
    {
        public string Name { get; set; }
    }
}
