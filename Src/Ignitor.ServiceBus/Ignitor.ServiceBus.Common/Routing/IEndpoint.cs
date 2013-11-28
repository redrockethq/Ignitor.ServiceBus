using System.Collections.Generic;
using FlitBit.Dto;

namespace Ignitor.ServiceBus.Common.Routing
{
    [DTO]
    public interface IEndpoint
    {
        string Name { get; set; }
        string Uri { get; set; }
        List<string> MessageTypes { get; set; }
    }
}