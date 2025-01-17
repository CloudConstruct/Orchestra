﻿using System;

namespace Orchestra.Networking.Flv.Data
{
    public class FlvVideoData
    {
        public FrameType FrameType { get; set; }
        public CodecId CodecId { get; set; }

        public ReadOnlyMemory<byte> VideoData { get; set; }

    }
}
