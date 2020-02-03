using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ProducesHeaderAttribute : Attribute
    {
        public ProducesHeaderAttribute(string header)
            : this(header, null, null, null)
        { }

        public ProducesHeaderAttribute(string header, string description)
            : this(header, null, null, description)
        { }

        public ProducesHeaderAttribute(string header, int statusCode)
            : this(header, null, statusCode, null)
        { }

        public ProducesHeaderAttribute(string header, int statusCode, string description)
            : this(header, null, statusCode, description)
        { }

        public ProducesHeaderAttribute(string header, Type valueType)
            : this(header, valueType, null, null)
        { }

        public ProducesHeaderAttribute(string header, Type valueType, string description)
            : this(header, valueType, null, description)
        { }

        public ProducesHeaderAttribute(string header, Type valueType = null, int? statusCode = null, string description = null)
        {
            Header = header;
            ValueType = valueType;
            StatusCode = statusCode;
            Description = description;
        }

        public string Header { get; }
        public Type ValueType { get; }
        public int? StatusCode { get; }
        public string Description { get; }
    }
}
