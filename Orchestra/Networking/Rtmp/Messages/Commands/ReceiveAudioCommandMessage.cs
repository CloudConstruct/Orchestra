﻿using Orchestra.Networking.Rtmp.Serialization;

namespace Orchestra.Networking.Rtmp.Messages.Commands
{
    [RtmpCommand(Name = "receiveAudio")]
    public class ReceiveAudioCommandMessage : CommandMessage
    {
        [OptionalArgument]
        public bool IsReceive { get; set; }

        public ReceiveAudioCommandMessage(AmfEncodingVersion encoding) : base(encoding)
        {
        }
    }
}
