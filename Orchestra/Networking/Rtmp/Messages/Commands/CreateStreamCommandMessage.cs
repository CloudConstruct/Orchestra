using Orchestra.Networking.Rtmp.Serialization;

namespace Orchestra.Networking.Rtmp.Messages.Commands
{
    [RtmpCommand(Name = "createStream")]
    public class CreateStreamCommandMessage : CommandMessage
    {
        public CreateStreamCommandMessage(AmfEncodingVersion encoding) : base(encoding)
        {
        }
    }
}
