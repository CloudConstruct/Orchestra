using Orchestra.Networking.Rtmp.Serialization;

namespace Orchestra.Networking.Rtmp.Messages.Commands
{
    [RtmpCommand(Name = "deleteStream")]
    public class DeleteStreamCommandMessage : CommandMessage
    {
        [OptionalArgument]
        public double StreamID { get; set; }

        public DeleteStreamCommandMessage(AmfEncodingVersion encoding) : base(encoding)
        {
        }
    }
}
