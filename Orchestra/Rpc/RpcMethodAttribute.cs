using System;

namespace Orchestra.Rpc
{
    public class RpcMethodAttribute : Attribute
    {
        public string Name { get; set; } = null;
        public RpcMethodAttribute(string name = null)
        {
            Name = name;
        }

    }
}