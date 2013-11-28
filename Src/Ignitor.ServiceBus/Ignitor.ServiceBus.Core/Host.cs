using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Ignitor.ServiceBus.Common;

namespace Ignitor.ServiceBus.Core
{
    [ContainerRegister(typeof(IHost), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.LockedSingleton)]
    public class Host : IHost
    {
        public Host()
        {
            // Get Routing Table

        }
    }
}
