using System;
using System.Runtime.InteropServices;
using FlitBit.Dto;

namespace Ignitor.ServiceBus.Common
{
    [DTO]
    public interface IMessage
    {
        Guid Id { get; set; }
        IMessageOptions Options { get; set; }
    }

    [DTO]
    public interface IMessageOptions
    {
        PriorityKind Priority { get; set; }
    }

    public enum PriorityKind
    {
        High,
        Important,
        Normal = 0,
        Low
    }

    public interface IMessageHandler<TMessage> where TMessage : IMessage
    {
        void Handle(TMessage message);
    }
}