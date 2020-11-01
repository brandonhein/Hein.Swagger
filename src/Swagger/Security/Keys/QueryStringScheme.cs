namespace Hein.Swagger.Security.Keys
{
    public class QueryStringScheme : ApiKeyBase
    {
        public QueryStringScheme(string name, string description = null) : base(name, description)
        {
            base.In = Microsoft.OpenApi.Models.ParameterLocation.Query;
        }
    }
}
