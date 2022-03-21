using Orchestra.Networking.Rtmp.Data;
using Orchestra.Networking.Rtmp.Serialization;
using Orchestra.Networking.Utils;

namespace Orchestra.Networking.Rtmp.Messages
{
    [RtmpMessage(MessageType.AbortMessage)]
    public class AbortMessage : ControlMessage
    {
        public uint AbortedChunkStreamId { get; set; }

        public AbortMessage() : base()
        {
        }

        public override void Deserialize(SerializationContext context)
        {
            AbortedChunkStreamId = NetworkBitConverter.ToUInt32(context.ReadBuffer.Span);
        }

        public override void Serialize(SerializationContext context)
        {
            var buffer = _arrayPool.Rent(sizeof(uint));
            try
            {
                NetworkBitConverter.TryGetBytes(AbortedChunkStreamId, buffer);
                context.WriteBuffer.WriteToBuffer(buffer);
            }
            finally
            {
                _arrayPool.Return(buffer);
            }
        }
    }
}
