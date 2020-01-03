using System;
using System.Collections.Generic;
using System.Text;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerSummaryAttribute : Attribute
    {
        public SwaggerSummaryAttribute(string summary)
        {
            Summary = summary;
        }

        public string Summary { get; }
    }

    public class SummaryAttribute : SwaggerSummaryAttribute
    {
        public SummaryAttribute(string summary) : base(summary)
        { }
    }
}
