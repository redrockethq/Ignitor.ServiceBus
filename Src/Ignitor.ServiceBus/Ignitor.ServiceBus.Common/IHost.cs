using Ignitor.ServiceBus.Common.Routing;

namespace Ignitor.ServiceBus.Common
{
    public interface IHostConfiguration
    {
        
    }

    public interface IHost
    {
        IRouter Router { get; }
        IHostConfiguration Configuration { get; }
        IBus Bus { get; }
    }
}