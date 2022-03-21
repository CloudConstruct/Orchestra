using Orchestra.Hosting;
using System.Net;
using System.Threading.Tasks;

namespace demo
{
    class Program
    {
        static async Task Main(string[] _)
        {
            var server = new RtmpServerBuilder()
                .UseStartup<Startup>()
                .UseWebSocket(c =>
                {
                    c.BindEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 8080);
                })
                .Build();
            await server.StartAsync();
        }
    }
}
