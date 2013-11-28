using FlitBit.Dto;
using Microsoft.AspNet.SignalR.Client;

namespace Ignitor.ServiceBus.Core.Protocols
{
    [DTO]
    public interface IProtocol
    {
        string Name { get; set; }
    }

    [DTO]
    public interface IHubProtocol : IProtocol
    {
        HubConnection Connection { get; set; }
        IHubProxy Proxy { get; set; }
    }
}