using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ExcludeFromSwaggerAttribute : ApiExplorerSettingsAttribute
    {
        public ExcludeFromSwaggerAttribute() : base()
        {
            base.IgnoreApi = true;
        }
    }
}
