using Hein.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerDescriptionFilter : IOperationFilter, IParameterFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionAttr = context.ApiDescription.ActionAttributes()
                .OfType<SwaggerDescriptionAttribute>().FirstOrDefault();

            if (actionAttr != null)
                operation.Description = actionAttr.Description;
        }

        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            var paramterAttr = context.ApiParameterDescription.CustomAttributes()
                .OfType<SwaggerDescriptionAttribute>().FirstOrDefault();

            if (paramterAttr != null)
                parameter.Description = paramterAttr.Description;
        }
    }
}
