namespace Hein.Swagger.Security.Keys
{
    public class QueryStringSecurityScheme : ApiKeySchemeBase
    {
        public QueryStringSecurityScheme(string name, string description = null) : base(name, description)
        {
            base.In = Microsoft.OpenApi.Models.ParameterLocation.Query;
        }
    }
}
