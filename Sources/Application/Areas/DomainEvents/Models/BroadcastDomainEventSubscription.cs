using System;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models
{
    public class BroadcastDomainEventSubscription : IDomainEventSubscription
    {
        private readonly Action<DomainEvent> _callback;

        public BroadcastDomainEventSubscription(Action<DomainEvent> callback)
        {
            _callback = callback;
        }

        public void ExecuteCallback(DomainEvent domainEvent)
        {
            _callback(domainEvent);
        }
    }
}