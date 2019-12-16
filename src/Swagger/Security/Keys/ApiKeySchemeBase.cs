namespace Hein.Swagger.Security.Keys
{
    public abstract class ApiKeySchemeBase : SecuritySchemeBase
    {
        protected ApiKeySchemeBase(string name, string description = null)
        {
            base.Name = name;
            base.Description = description;
            base.Type = "apiKey";
        }

        public string In { get; set; }
    }
}
