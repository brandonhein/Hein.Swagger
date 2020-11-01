namespace Hein.Swagger.Security.Keys
{
    public class HeaderScheme : ApiKeyBase
    {
        public HeaderScheme(string name, string description = null) : base(name, description)
        {
            base.In = Microsoft.OpenApi.Models.ParameterLocation.Header;
        }
    }
}
