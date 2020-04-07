using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Hein.Swagger.Filters
{

    public class SwaggerVersionDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths
                .ToDictionary(
                    path => path.Key.Replace("v{version}", swaggerDoc.Info.Version),
                    path => path.Value
                );

            var pathsToSet = new OpenApiPaths();
            foreach (var path in paths)
            {
                pathsToSet.Add(path.Key, path.Value);
            }
            swaggerDoc.Paths = pathsToSet;
        }
    }
}
