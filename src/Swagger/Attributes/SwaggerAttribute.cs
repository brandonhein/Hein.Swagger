using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SwaggerAttribute : ApiExplorerSettingsAttribute
    {
        public SwaggerAttribute() : base()
        {
            base.IgnoreApi = false;
        }
    }
}
