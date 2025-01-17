﻿using Orchestra.Networking.Rtmp.Serialization;

namespace Orchestra.Networking.Rtmp.Messages.Commands
{
    [RtmpCommand(Name = "publish")]
    public class PublishCommandMessage : CommandMessage
    {
        [OptionalArgument]
        public string PublishingName { get; set; }
        [OptionalArgument]
        public string PublishingType { get; set; }

        public PublishCommandMessage(AmfEncodingVersion encoding) : base(encoding)
        {
        }
    }
}
