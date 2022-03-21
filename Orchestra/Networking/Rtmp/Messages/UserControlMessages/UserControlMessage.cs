using Orchestra.Networking.Rtmp.Data;
using Orchestra.Networking.Rtmp.Serialization;

namespace Orchestra.Networking.Rtmp.Messages.UserControlMessages
{
    public enum UserControlEventType : ushort
    {
        StreamBegin,
        StreamEof,
        StreamDry,
        SetBufferLength,
        StreamIsRecorded,
        PingRequest,
        PingResponse
    }

    [RtmpMessage(MessageType.UserControlMessages)]
    public abstract class UserControlMessage : ControlMessage
    {
        public UserControlEventType UserControlEventType { get; set; }

        public UserControlMessage() : base()
        {
        }

    }

}
