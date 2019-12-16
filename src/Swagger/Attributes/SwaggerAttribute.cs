using Microsoft.AspNetCore.Mvc;

namespace Hein.Swagger.Attributes
{
    public class SwaggerAttribute : ApiExplorerSettingsAttribute
    {
        public SwaggerAttribute() : base()
        {
            base.IgnoreApi = false;
        }
    }
}
