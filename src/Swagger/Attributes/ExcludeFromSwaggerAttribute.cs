using Microsoft.AspNetCore.Mvc;

namespace Hein.Swagger.Attributes
{
    public class ExcludeFromSwaggerAttribute : ApiExplorerSettingsAttribute
    {
        public ExcludeFromSwaggerAttribute() : base()
        {
            base.IgnoreApi = true;
        }
    }
}
