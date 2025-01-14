﻿using System.Collections.Generic;

namespace Orchestra.Networking.Amf.Serialization.Amf3
{
    public class Amf3Array
    {
        public Dictionary<string, object> SparsePart { get; set; } = new Dictionary<string, object>();
        public List<object> DensePart { get; set; } = new List<object>();


        public object this[string key]
        {
            get
            {
                return SparsePart[key];
            }
            set
            {
                SparsePart[key] = value;
            }
        }

        public object this[int index]
        {
            get
            {
                return DensePart[index];
            }
            set
            {
                DensePart[index] = value;
            }
        }
    }
}
