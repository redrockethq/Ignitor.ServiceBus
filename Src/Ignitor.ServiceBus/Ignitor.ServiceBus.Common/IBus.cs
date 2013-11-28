using System.Security.Cryptography.X509Certificates;
using Ignitor.ServiceBus.Common.Routing;

namespace Ignitor.ServiceBus.Common
{
    public interface IBus : IBusMessaging, IBusClientManagement
    {
        
    }

    public interface IBusMessaging
    {
        void Send<TMessage>(TMessage message);
        void Send<TMessage>(string name, TMessage message);
        void Send<TMessage>(IEndpoint endpoint, TMessage message);
        void Reply<TMessage>(TMessage message);
        void Reply<TMessage>(string name, TMessage message);
        void Reply<TMessage>(IEndpoint endpoint, TMessage message);
    }

    public interface IBusClientManagement
    {
        void Subscribe(IEndpoint endpoint);
        void Subscribe<TMessage>(IEndpoint endpoint, TMessage message);
        void UnSubscribe(IEndpoint endpoint);
        void UnSubscribe<TMessage>(IEndpoint endpoint, TMessage message);
    }
}
