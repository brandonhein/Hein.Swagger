using System.Collections.Generic;

namespace Hein.Swagger.Gen.Models
{
    public class SwaggerModel
    {
        public string Swagger { get; set; }
        public SwaggerInfo Info { get; set; }
        public SwaggerExternalDoc ExternalDocs { get; set; }
        public string BasePath { get; set; }
        public List<SwaggerTag> Tags { get; set; }
    }
}
