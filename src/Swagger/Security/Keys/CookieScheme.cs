namespace Hein.Swagger.Security.Keys
{
    public class CookieScheme : ApiKeyBase
    {
        public CookieScheme(string name, string description = null) : base(name, description)
        {
            base.In = Microsoft.OpenApi.Models.ParameterLocation.Cookie;
        }
    }
}
