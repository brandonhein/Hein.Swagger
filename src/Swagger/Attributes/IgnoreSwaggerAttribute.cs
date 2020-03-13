using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class IgnoreSwaggerAttribute : ApiExplorerSettingsAttribute
    {
        public IgnoreSwaggerAttribute() : base()
        {
            base.IgnoreApi = true;
        }
    }
}
