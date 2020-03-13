using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SwaggerDescriptionAttribute : Attribute
    {
        public SwaggerDescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class DescriptionAttribute : SwaggerDescriptionAttribute
    {
        public DescriptionAttribute(string description) : base(description)
        { }
    }
}
