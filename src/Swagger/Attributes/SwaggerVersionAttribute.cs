using System;

namespace Hein.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SwaggerVersionAttribute : Attribute
    {
        public SwaggerVersionAttribute(string version)
        {
            Version = version;
        }

        public string Version { get; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ApiVersionAttribute : SwaggerVersionAttribute
    {
        public ApiVersionAttribute(string version) : base(version)
        { }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class VersionAttribute : SwaggerVersionAttribute
    {
        public VersionAttribute(string version) : base(version)
        { }
    }
}
