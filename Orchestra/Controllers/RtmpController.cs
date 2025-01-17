﻿using Orchestra.Networking.Flv;
using Orchestra.Networking.Rtmp;
using Orchestra.Rpc;

namespace Orchestra.Controllers
{
    public abstract class RtmpController
    {
        public RtmpMessageStream MessageStream { get; internal set; } = null;
        public RtmpChunkStream ChunkStream { get; internal set; } = null;
        public RtmpSession RtmpSession { get; internal set; } = null;


        private FlvMuxer _flvMuxer = null;
        private FlvDemuxer _flvDemuxer = null;

        public FlvMuxer FlvMuxer
        {
            get
            {
                if (_flvMuxer == null)
                {
                    _flvMuxer = new FlvMuxer();
                }
                return _flvMuxer;
            }
        }
        public FlvDemuxer FlvDemuxer
        {
            get
            {
                if (_flvDemuxer == null)
                {
                    _flvDemuxer = new FlvDemuxer(RtmpSession.IOPipeline.Options.MessageFactories);
                }
                return _flvDemuxer;
            }
        }

        [RpcMethod("deleteStream")]
        public void DeleteStream([FromOptionalArgument] double streamId)
        {
            RtmpSession.DeleteNetStream((uint)streamId);
        }
    }
}
