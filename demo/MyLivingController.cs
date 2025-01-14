﻿using Orchestra.Controllers;
using Orchestra.Controllers.Living;
using Orchestra.Rpc;

namespace demo
{
    [NeverRegister]
    class MyLivingController : LivingController
    {
        [RpcMethod("createStream")]
        public new uint CreateStream()
        {
            var stream = RtmpSession.CreateNetStream<MyLivingStream>();
            return stream.MessageStream.MessageStreamId;
        }
    }
}
