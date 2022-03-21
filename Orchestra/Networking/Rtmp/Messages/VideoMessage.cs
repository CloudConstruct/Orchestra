using Orchestra.Networking.Rtmp.Data;
using Orchestra.Networking.Rtmp.Serialization;
using System;

namespace Orchestra.Networking.Rtmp.Messages
{
    [RtmpMessage(MessageType.VideoMessage)]
    public sealed class VideoMessage : Message, ICloneable
    {
        public ReadOnlyMemory<byte> Data { get; private set; }

        public object Clone()
        {
            var ret = new VideoMessage
            {
                MessageHeader = (MessageHeader)MessageHeader.Clone()
            };
            ret.MessageHeader.MessageStreamId = null;
            ret.Data = Data;
            return ret;
        }

        public override void Deserialize(SerializationContext context)
        {
            // TODO: optimize performance
            var data = new byte[context.ReadBuffer.Length];
            context.ReadBuffer.Span.Slice(0, (int)MessageHeader.MessageLength).CopyTo(data);
            Data = data;
        }

        public override void Serialize(SerializationContext context)
        {
            context.WriteBuffer.WriteToBuffer(Data.Span.Slice(0, Data.Length));
        }

    }
}
