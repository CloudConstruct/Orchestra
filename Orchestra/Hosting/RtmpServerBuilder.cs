using Orchestra.Controllers;
using Orchestra.Controllers.Living;
using Orchestra.Controllers.Record;
using Orchestra.Networking.Rtmp;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Orchestra.Hosting
{
    public class RtmpServerBuilder
    {
        private IStartup _startup = null;
        private X509Certificate2 _cert = null;
        private bool _useWebSocket = false;
        private bool _useSsl = false;
        private WebSocketOptions _websocketOptions = new();
        private RtmpServerOptions _options = new();

        public RtmpServerBuilder UseStartup<T>() where T : IStartup, new()
        {
            _startup = new T();
            return this;
        }
        public RtmpServerBuilder UseSsl(X509Certificate2 cert)
        {
            _useSsl = true;
            _cert = cert;
            return this;
        }

        public RtmpServerBuilder UseWebSocket(Action<WebSocketOptions> conf = null)
        {
            _useWebSocket = true;
            conf?.Invoke(_websocketOptions);
            return this;
        }

        public RtmpServerBuilder UseRtmp(Action<RtmpServerOptions> config = null)
        {
            config?.Invoke(_options);
            return this;
        }

        public RtmpServer Build()
        {
            _options ??= new RtmpServerOptions();
            _options.Startup = _startup ?? new EmptyStartup();
            var types = Assembly.GetCallingAssembly().GetTypes();

            var registerInternalControllers = true;
            _websocketOptions._serverOptions = _options;
            foreach (var type in types)
            {
                var neverRegister = type.GetCustomAttribute<NeverRegisterAttribute>();
                if (neverRegister != null)
                {
                    continue;
                }

                if (typeof(NetStream).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    _options.RegisterStream(type);
                }
                else if (typeof(RtmpController).IsAssignableFrom(type) && !type.IsAbstract)
                {
                    _options.RegisterController(type);
                }

                if (typeof(LivingController).IsAssignableFrom(type))
                {
                    registerInternalControllers = false;
                }
                if (_useWebSocket)
                {
                    if (typeof(WebSocketController).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        _websocketOptions.RegisterController(type);
                    }
                    if (typeof(WebSocketPlayController).IsAssignableFrom(type))
                    {
                        registerInternalControllers = false;
                    }
                }
            }

            if (registerInternalControllers)
            {
                _options.RegisterController<LivingController>();
                _options.RegisterStream<LivingStream>();
                _options.RegisterStream<RecordStream>();
                _options.RegisterController<RecordController>();
                if (_useWebSocket)
                {
                    _websocketOptions.RegisterController<WebSocketPlayController>();
                }
            }

            if (_useSsl)
            {
                _options.Cert = _cert;
            }
            _options.CleanupRpcRegistration();
            _options.BuildContainer();
            var ret = new RtmpServer(_options, _websocketOptions);
            return ret;
        }

    }
}