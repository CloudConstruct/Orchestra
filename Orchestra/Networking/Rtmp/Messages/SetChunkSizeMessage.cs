﻿using Orchestra.Networking.Rtmp.Data;
using Orchestra.Networking.Rtmp.Serialization;
using Orchestra.Networking.Utils;
using System;

namespace Orchestra.Networking.Rtmp.Messages
{
    [RtmpMessage(MessageType.SetChunkSize)]
    public class SetChunkSizeMessage : ControlMessage
    {
        public uint ChunkSize { get; set; }

        public SetChunkSizeMessage() : base()
        {

        }

        public override void Deserialize(SerializationContext context)
        {
            var chunkSize = NetworkBitConverter.ToInt32(context.ReadBuffer.Span);
            ChunkSize = (uint)chunkSize;
        }

        public override void Serialize(SerializationContext context)
        {
            var buffer = _arrayPool.Rent(sizeof(uint));
            try
            {
                NetworkBitConverter.TryGetBytes(ChunkSize, buffer);
                context.WriteBuffer.WriteToBuffer(buffer.AsSpan(0, sizeof(uint)));
            }
            finally
            {
                _arrayPool.Return(buffer);
            }

        }
    }
}
