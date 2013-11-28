using System;
using System.Collections.Generic;
using System.Linq;
using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Ignitor.ServiceBus.Common.Routing;

namespace Ignitor.ServiceBus.Core.Routing
{
    [ContainerRegister(typeof(IRouter), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.Singleton)]
    public class Router : IRouter
    {
        public IEndpoint Current { get; set; }

        public IDictionary<string, IEndpoint> Endpoints
        {
            get { return EndpointManager.Endpoints; }
        }

        protected IEndpointManager EndpointManager { get; set; }

        public Router(IEndpoint current, IEndpointManager endpointManager)
        {
            Current = current;
            EndpointManager = endpointManager;
        }

        public IEndpoint Resolve(string name)
        {
            return Endpoints[name.ToLower()];
        }


        public IEnumerable<IEndpoint> ResolveByType(string type)
        {
            return Endpoints.Values.Where(u => u.MessageTypes.Any(t => t.Equals(type, StringComparison.CurrentCultureIgnoreCase)));
        }

        public IEnumerable<IEndpoint> ResolveByType(Type type)
        {
            return Endpoints.Values.Where(u => u.MessageTypes.Any(t => t.Equals(type.FullName, StringComparison.CurrentCultureIgnoreCase)));
        }

        public IEnumerable<IEndpoint> ResolveByType<TMessage>(TMessage message)
        {
            return ResolveByType(message.GetType());
        }
    }
}
