using Orchestra.Networking.Rtmp;
using Orchestra.Rpc;

namespace Orchestra.Controllers.Living
{
    public class LivingController : RtmpController
    {
        [RpcMethod("createStream")]
        public uint CreateStream()
        {
            var stream = RtmpSession.CreateNetStream<LivingStream>();
            return stream.MessageStream.MessageStreamId;
        }
    }
}
