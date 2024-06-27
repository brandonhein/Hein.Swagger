using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SwaggerControllerAttribute : SwaggerTagAttribute
    {
        public SwaggerControllerAttribute(string groupName) : base(groupName)
        { }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SwaggerGroupAttribute : SwaggerTagAttribute
    {
        public SwaggerGroupAttribute(string groupName) : base(groupName)
        { }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SwaggerTagAttribute : Attribute
    {
        public SwaggerTagAttribute(string tagName)
        {
            TagName = tagName;
        }

        public string TagName { get; }
    }
}
