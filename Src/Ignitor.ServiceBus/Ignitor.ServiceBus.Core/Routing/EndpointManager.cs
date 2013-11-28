using System.Collections.Generic;
using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Ignitor.ServiceBus.Common.Routing;

namespace Ignitor.ServiceBus.Core.Routing
{
    [ContainerRegister(typeof(IEndpointManager), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.Singleton)]
    public class EndpointManager : IEndpointManager
    {
        public IDictionary<string, IEndpoint> Endpoints { get; private set; }

        public EndpointManager(IDictionary<string, IEndpoint> endpoints)
        {
            Endpoints = endpoints;
        }

        public void Save(IEndpoint endpoint)
        {
            var key = endpoint.Name.ToLower();
            if (Endpoints.ContainsKey(key))
                Endpoints[key] = endpoint;
            else
                Endpoints.Add(key, endpoint);
        }

        public void Remove(string name)
        {
            var key = name.ToLower();
            if (Endpoints.ContainsKey(key))
                Endpoints.Remove(key);
        }

        public void Clear()
        {
            Endpoints.Clear();
        }
    }
}