using Orchestra.Networking.Rtmp.Messages.UserControlMessages;
using System;

namespace Orchestra.Networking.Rtmp.Serialization
{
    public class UserControlMessageAttribute : Attribute
    {
        public UserControlEventType Type { get; set; }
    }
}
