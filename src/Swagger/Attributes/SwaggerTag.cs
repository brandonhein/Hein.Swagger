using System;

namespace Hein.Swagger.Attributes
{
    public class SwaggerTagAttribute : TagAttribute
    {
        public SwaggerTagAttribute(string tagName) : base(tagName)
        { }
    }

    public class TagAttribute : Attribute
    {
        public TagAttribute(string tagName)
        {
            TagName = tagName;
        }

        public string TagName { get; set; }
    }
}
