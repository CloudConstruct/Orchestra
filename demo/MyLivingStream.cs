using Orchestra.Controllers;
using Orchestra.Controllers.Living;
using Orchestra.Rpc;
using Orchestra.Service;
using System.Threading.Tasks;

namespace demo
{
    [NeverRegister]
    public class MyLivingStream : LivingStream
    {
        public MyLivingStream(PublisherSessionService publisherSessionService) : base(publisherSessionService)
        {
        }

        [RpcMethod("play")]
        public override async Task Play(
            [FromOptionalArgument] string streamName,
            [FromOptionalArgument] double start = -1,
            [FromOptionalArgument] double duration = -1,
            [FromOptionalArgument] bool reset = false)
        {
            // Do some check or other stuff

            await base.Play(streamName, start, duration, reset);
        }
    }
}
