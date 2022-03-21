using Autofac;

namespace Orchestra.Hosting
{
    internal class EmptyStartup : IStartup
    {
        public void ConfigureServices(ContainerBuilder builder)
        {
        }
    }
}
