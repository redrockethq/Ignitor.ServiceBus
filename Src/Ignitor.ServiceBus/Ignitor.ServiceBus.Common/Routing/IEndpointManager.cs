using System.Collections.Generic;

namespace Ignitor.ServiceBus.Common.Routing
{
    public interface IEndpointManager
    {
        IDictionary<string, IEndpoint> Endpoints { get; }
        void Save(IEndpoint endpoint);
        void Remove(string name);
        void Clear();
    }
}