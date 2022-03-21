using Orchestra.Buffers;
using System;

namespace Orchestra.Networking.Amf.Data
{
    public interface IExternalizable
    {
        bool TryDecodeData(Span<byte> buffer, out int consumed);

        bool TryEncodeData(ByteBuffer buffer);
    }
}
