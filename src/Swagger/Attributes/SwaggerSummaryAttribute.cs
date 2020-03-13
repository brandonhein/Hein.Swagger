using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SwaggerSummaryAttribute : Attribute
    {
        public SwaggerSummaryAttribute(string summary)
        {
            Summary = summary;
        }

        public string Summary { get; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SummaryAttribute : SwaggerSummaryAttribute
    {
        public SummaryAttribute(string summary) : base(summary)
        { }
    }
}
