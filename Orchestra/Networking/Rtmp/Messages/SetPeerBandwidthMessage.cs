﻿using Orchestra.Networking.Rtmp.Data;
using Orchestra.Networking.Rtmp.Serialization;
using Orchestra.Networking.Utils;
using System;

namespace Orchestra.Networking.Rtmp.Messages
{
    public enum LimitType : byte
    {
        Hard,
        Soft,
        Dynamic
    }

    [RtmpMessage(MessageType.SetPeerBandwidth)]
    public class SetPeerBandwidthMessage : ControlMessage
    {
        public uint WindowSize { get; set; }
        public LimitType LimitType { get; set; }

        public SetPeerBandwidthMessage() : base()
        {
        }

        public override void Deserialize(SerializationContext context)
        {
            WindowSize = NetworkBitConverter.ToUInt32(context.ReadBuffer.Span);
            LimitType = (LimitType)context.ReadBuffer.Span.Slice(sizeof(uint))[0];
        }

        public override void Serialize(SerializationContext context)
        {
            var buffer = _arrayPool.Rent(sizeof(uint) + sizeof(byte));
            try
            {
                NetworkBitConverter.TryGetBytes(WindowSize, buffer);
                buffer.AsSpan(sizeof(uint))[0] = (byte)LimitType;
                context.WriteBuffer.WriteToBuffer(buffer.AsSpan(0, sizeof(uint) + sizeof(byte)));
            }
            finally
            {
                _arrayPool.Return(buffer);
            }
        }
    }
}
