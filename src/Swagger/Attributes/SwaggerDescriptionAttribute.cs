using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerDescriptionAttribute : Attribute
    {
        public SwaggerDescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }

    public class DescriptionAttribute : SwaggerDescriptionAttribute
    {
        public DescriptionAttribute(string description) : base(description)
        { }
    }
}
