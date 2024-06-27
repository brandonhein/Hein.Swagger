using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System;
using System.Linq;
using Hein.Swagger.Attributes;

namespace Hein.Swagger.Filters
{
    public class SwaggerOrderDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new Dictionary<KeyValuePair<string, OpenApiPathItem>, int>();
            foreach (var path in swaggerDoc.Paths)
            {
                var apiDescription = context.ApiDescriptions.FirstOrDefault(x =>
                    x.RelativePath.Replace("/", "").Equals(path.Key.Replace("/", ""), StringComparison.OrdinalIgnoreCase));

                var attr = new SwaggerOrderAttribute(int.MaxValue);
                if (apiDescription != null)
                {
                    var foundAttr = apiDescription.ControllerAttributes()
                        .OfType<SwaggerOrderAttribute>().FirstOrDefault();

                    if (foundAttr != null)
                        attr = foundAttr;
                }

                paths.Add(path, attr.Order);
            }

            var orderedPaths = paths.OrderBy(x => x.Value).ThenBy(x => x.Key.Key).ToList();
            swaggerDoc.Paths.Clear();
            foreach (var path in orderedPaths)
            {
                swaggerDoc.Paths.Add(path.Key.Key, path.Key.Value);
            }
        }
    }
}
