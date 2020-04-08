namespace Hein.Swagger.Security.Keys
{
    public class HeaderSecurityScheme : ApiKeySchemeBase
    {
        public HeaderSecurityScheme(string name, string description = null) : base(name, description)
        {
            base.In = Microsoft.OpenApi.Models.ParameterLocation.Header;
        }
    }
}
