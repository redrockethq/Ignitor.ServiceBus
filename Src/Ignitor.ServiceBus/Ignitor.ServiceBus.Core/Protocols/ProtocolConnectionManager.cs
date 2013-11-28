using System;
using System.Collections.Generic;
using System.Linq;
using FlitBit.IoC;
using Ignitor.ServiceBus.Common;
using Ignitor.ServiceBus.Common.Routing;
using Microsoft.AspNet.SignalR.Client;

namespace Ignitor.ServiceBus.Core.Protocols
{
    public interface IProtocolConnectionManager
    {
        void Connect();
    }

    public interface IHubProtocolConnectionManager : IProtocolConnectionManager
    {
        IDictionary<string, IHubProtocol> Protocols { get; }
    }

    public class HubProtocolConnectionManager : IProtocolConnectionManager
    {
        protected IDictionary<string, IHubProtocol> Protocols { get; private set; }

        public HubProtocolConnectionManager(IEndpointManager endpointManager)
        {
            Protocols = SetupProtocols(endpointManager);
            Connect();
        }
        public async void Connect()
        {
            foreach (var key in Protocols.Keys)
                await Protocols[key].Connection.Start();
        }

        IDictionary<string, IHubProtocol> SetupProtocols(IEndpointManager endpointManager)
        {
            var protocols = new Dictionary<string, IHubProtocol>();
            foreach (var endpoint in endpointManager.Endpoints.Where(e => !protocols.Keys.Contains(e.Key)))
            {
                var hubProtocol = Create.New<IHubProtocol>();
                hubProtocol.Connection = new HubConnection(endpoint.Value.Uri)
                {
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                
                hubProtocol.Proxy = hubProtocol.Connection.CreateHubProxy("Messaging");
                protocols.Add(endpoint.Key, hubProtocol);
            }

            return protocols;
        }
    }
}
