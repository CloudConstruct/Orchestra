﻿using Harmonic.Buffers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harmonic.Networking.Amf.Serialization.Amf3
{
    public class SerializationContext : IDisposable
    {
        public UnlimitedBuffer Buffer { get; set; } = new UnlimitedBuffer();
        public List<object> ObjectReferenceTable { get; set; } = new List<object>();
        public List<string> StringReferenceTable { get; set; } = new List<string>();
        public List<Amf3ClassTraits> ObjectTraitsReferenceTable { get; set; } = new List<Amf3ClassTraits>();

        public int MessageLength =>< Buffer.BufferLength;

        public void Dispose()
        {
            ((IDisposable)Buffer).Dispose();
        }

        public void GetMessage(Span<byte> buffer)
        {
            ObjectReferenceTable.Clear();
            StringReferenceTable.Clear();
            ObjectTraitsReferenceTable.Clear();
            Buffer.TakeOutMemory(buffer);
        }

    }
}
