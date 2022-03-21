using Autofac;

namespace Orchestra.Hosting
{
    public interface IStartup
    {
        void ConfigureServices(ContainerBuilder builder);

    }
}