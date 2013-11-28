using System;
using System.Collections.Generic;

namespace Ignitor.ServiceBus.Common.Routing
{
    public interface IRouter
    {
        IDictionary<string, IEndpoint> Endpoints { get; }
        IEndpoint Current { get; }
        IEndpoint Resolve(string name);

        

        IEnumerable<IEndpoint> ResolveByType(string type);
        IEnumerable<IEndpoint> ResolveByType(Type type);
        IEnumerable<IEndpoint> ResolveByType<TMessage>(TMessage message);
    }
}