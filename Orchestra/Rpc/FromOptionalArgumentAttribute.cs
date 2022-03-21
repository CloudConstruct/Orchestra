using System;

namespace Orchestra.Rpc
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromOptionalArgumentAttribute : Attribute
    {
    }
}
