using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hein.Swagger
{
    public static class ApiDescriptionExtensions
    {
        public static IEnumerable<object> ActionAttributes(this ApiDescription apiDescription)
        {
            return GetAttributes(apiDescription);
        }

        public static IEnumerable<object> ControllerAttributes(this ApiDescription apiDescription)
        {
            return GetAttributes(apiDescription);
        }

        private static IEnumerable<object> GetAttributes(ApiDescription apiDescription)
        {
            if (apiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
            {
                return methodInfo.GetCustomAttributes(true)
                    .Union(methodInfo.DeclaringType.GetCustomAttributes(true));
            }

            return Enumerable.Empty<object>();
        }
    }
}
