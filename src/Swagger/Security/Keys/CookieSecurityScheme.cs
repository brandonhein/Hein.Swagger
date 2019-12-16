namespace Hein.Swagger.Security.Keys
{
    public class CookieSecurityScheme : ApiKeySchemeBase
    {
        public CookieSecurityScheme(string name, string description = null) : base(name, description)
        {
            In = "cookie";
        }
    }
}
