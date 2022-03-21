using System.Threading.Tasks;

namespace Orchestra.Networking.Rtmp
{
    class WriteState
    {
        public byte[] Buffer;
        public int Length;
        public TaskCompletionSource<int> TaskSource = null;
    }
}
