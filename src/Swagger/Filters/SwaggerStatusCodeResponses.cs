using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Net;

namespace Hein.Swagger.Filters
{
    public class SwaggerStatusCodeResponses : IOperationFilter
    {
        private readonly HttpStatusCode[] _codes;
        public SwaggerStatusCodeResponses(HttpStatusCode[] codes)
        {
            _codes = codes.Distinct().ToArray();
        }

        public void Apply(Operation operation, OperationFilterContext context)
        {
            foreach (var code in _codes)
            {
                var codeNumber = (int)code;
                try
                {
                    operation.Responses.Add(codeNumber.ToString(), new Response() { Description = code.ToString() });
                }
                catch { }
            }
        }
    }
}
