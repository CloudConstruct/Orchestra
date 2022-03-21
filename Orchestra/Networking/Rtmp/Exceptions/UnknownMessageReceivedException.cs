using Orchestra.Networking.Rtmp.Data;
using System;

namespace Orchestra.Networking.Rtmp.Exceptions
{
    public class UnknownMessageReceivedException : Exception
    {
        public MessageHeader Header { get; set; }

        public UnknownMessageReceivedException(MessageHeader header)
        {
            Header = header;
        }
    }
}
