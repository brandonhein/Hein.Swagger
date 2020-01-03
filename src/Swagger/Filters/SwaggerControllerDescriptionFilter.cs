using Hein.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Hein.Swagger.Filters
{
    //TODO ISSUE/FEATURE #1
    //public class SwaggerControllerDescriptionFilter : IDocumentFilter
    //{
    //    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    //    {
    //        foreach (var des in context.ApiDescriptions)
    //        {
    //            var controllerAttr = des.ControllerAttributes()
    //                .OfType<SwaggerDescriptionAttribute>().FirstOrDefault();
    //
    //            if (controllerAttr != null)
    //            {
    //                var matchedTag = swaggerDoc.Tags?.FirstOrDefault(x => x.Name == des.GroupName);
    //                if (matchedTag != null)
    //                {
    //                    matchedTag.Description = controllerAttr.Description;
    //                }
    //            }
    //        }
    //    }
    //}
}
