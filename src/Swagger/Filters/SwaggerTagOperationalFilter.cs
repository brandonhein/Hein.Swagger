using Hein.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerTagOperationalFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var groups = context
                .ApiDescription
                .ControllerAttributes()
                .OfType<TagAttribute>()
                .Select(x => x.TagName)
                .ToList();

            if (groups.Count == 0)
            {
                return;
            }

            var tags = operation.Tags?.Select(x => x).ToList() ?? new List<string>();

            var controllerDescriptor = context.ApiDescription.GetProperty<ControllerActionDescriptor>();
            if (controllerDescriptor != null)
            {
                tags.Remove(controllerDescriptor.ControllerName);
            }

            foreach (var apiGroupName in groups)
            {
                if (!tags.Contains(apiGroupName))
                {
                    tags.Add(apiGroupName);
                }
            }

            operation.Tags = tags;
        }
    }
}
