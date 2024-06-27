using System;
using System.Collections.Generic;
using System.Text;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SwaggerOrderAttribute : Attribute
    {
        public SwaggerOrderAttribute(int order) 
        {
            Order = order;
        }

        public int Order { get; }
    }
}
