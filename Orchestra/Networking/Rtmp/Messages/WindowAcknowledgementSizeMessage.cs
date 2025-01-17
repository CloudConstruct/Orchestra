﻿using Orchestra.Networking.Rtmp.Data;
using Orchestra.Networking.Rtmp.Serialization;
using Orchestra.Networking.Utils;
using System;
using System.Buffers;

namespace Orchestra.Networking.Rtmp.Messages
{
    [RtmpMessage(MessageType.WindowAcknowledgementSize)]
    public class WindowAcknowledgementSizeMessage : ControlMessage
    {
        public uint WindowSize { get; set; }

        public WindowAcknowledgementSizeMessage() : base()
        {
        }

        public override void Deserialize(SerializationContext context)
        {
            WindowSize = NetworkBitConverter.ToUInt32(context.ReadBuffer.Span);
        }

        public override void Serialize(SerializationContext context)
        {
            var arr = ArrayPool<byte>.Shared.Rent(sizeof(uint));
            try
            {
                NetworkBitConverter.TryGetBytes(WindowSize, arr);
                context.WriteBuffer.WriteToBuffer(arr.AsSpan(0, sizeof(uint)));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(arr);
            }
        }
    }
}
