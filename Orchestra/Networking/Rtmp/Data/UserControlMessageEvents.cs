namespace Orchestra.Networking.Rtmp.Data
{
    public enum UserControlMessageEvents : ushort
    {
        StreamBegin,
        StreamEOF,
        StreamDry,
        SetBufferLength,
        StreamIsRecorded,
        PingRequest,
        PingResponse
    }
}
