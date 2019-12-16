using Microsoft.AspNetCore.Mvc;

namespace Hein.Swagger.Attributes
{
    public class IgnoreSwaggerAttribute : ApiExplorerSettingsAttribute
    {
        public IgnoreSwaggerAttribute() : base()
        {
            base.IgnoreApi = true;
        }
    }
}
