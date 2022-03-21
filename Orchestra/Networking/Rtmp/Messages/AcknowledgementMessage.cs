using Orchestra.Networking.Rtmp.Data;
using Orchestra.Networking.Rtmp.Serialization;
using Orchestra.Networking.Utils;
using System;

namespace Orchestra.Networking.Rtmp.Messages
{
    [RtmpMessage(MessageType.Acknowledgement)]
    public class AcknowledgementMessage : ControlMessage
    {
        public uint BytesReceived { get; set; }

        public AcknowledgementMessage() : base()
        {
        }

        public override void Deserialize(SerializationContext context)
        {
            BytesReceived = NetworkBitConverter.ToUInt32(context.ReadBuffer.Span);
        }

        public override void Serialize(SerializationContext context)
        {
            var buffer = _arrayPool.Rent(sizeof(uint));
            try
            {
                NetworkBitConverter.TryGetBytes(BytesReceived, buffer);
                context.WriteBuffer.WriteToBuffer(buffer.AsSpan(0, sizeof(uint)));
            }
            finally
            {
                _arrayPool.Return(buffer);
            }

        }
    }
}
