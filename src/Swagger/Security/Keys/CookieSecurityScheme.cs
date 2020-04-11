namespace Hein.Swagger.Security.Keys
{
    public class CookieSecurityScheme : ApiKeySchemeBase
    {
        public CookieSecurityScheme(string name, string description = null) : base(name, description)
        {
            base.In = Microsoft.OpenApi.Models.ParameterLocation.Cookie;
        }
    }
}
