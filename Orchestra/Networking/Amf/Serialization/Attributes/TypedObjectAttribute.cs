using System;

namespace Orchestra.Networking.Amf.Serialization.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TypedObjectAttribute : Attribute
    {
        public string Name { get; set; } = null;
    }
}
