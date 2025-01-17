﻿using Orchestra.Networking.Rtmp.Serialization;

namespace Orchestra.Networking.Rtmp.Messages.Commands
{
    [RtmpCommand(Name = "seek")]
    public class SeekCommandMessage : CommandMessage
    {
        [OptionalArgument]
        public double MilliSeconds { get; set; }

        public SeekCommandMessage(AmfEncodingVersion encoding) : base(encoding)
        {
        }
    }
}
