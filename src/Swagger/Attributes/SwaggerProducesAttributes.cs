using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ProducesHeaderAttribute : Attribute
    {
        public ProducesHeaderAttribute(string header)
            : this(header, default(SwaggerType), null, null)
        { }

        public ProducesHeaderAttribute(string header, string description)
            : this(header, default(SwaggerType), null, description)
        { }

        public ProducesHeaderAttribute(string header, int statusCode)
            : this(header, default(SwaggerType), statusCode, null)
        { }

        public ProducesHeaderAttribute(string header, int statusCode, string description)
            : this(header, default(SwaggerType), statusCode, description)
        { }

        public ProducesHeaderAttribute(string header, SwaggerType valueType)
            : this(header, valueType, null, null)
        { }

        public ProducesHeaderAttribute(string header, SwaggerType valueType, string description)
            : this(header, valueType, null, description)
        { }

        public ProducesHeaderAttribute(string header, SwaggerType valueType = default(SwaggerType), int? statusCode = null, string description = null)
        {
            Header = header;
            ValueType = valueType;
            StatusCode = statusCode;
            Description = description;
        }

        public string Header { get; }
        public SwaggerType ValueType { get; }
        public int? StatusCode { get; }
        public string Description { get; }
    }

    public enum SwaggerType
    {
        String,
        Number,
        Integer,
        Boolean,
        Array,
        Object
    }
}
