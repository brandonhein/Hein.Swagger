using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerControllerAttribute : SwaggerTagAttribute
    {
        public SwaggerControllerAttribute(string groupName) : base(groupName)
        { }
    }

    public class SwaggerGroupAttribute : SwaggerTagAttribute
    {
        public SwaggerGroupAttribute(string groupName) : base(groupName)
        { }
    }

    public class SwaggerTagAttribute : Attribute
    {
        public SwaggerTagAttribute(string tagName)
        {
            TagName = tagName;
        }

        public string TagName { get; }
    }
}
