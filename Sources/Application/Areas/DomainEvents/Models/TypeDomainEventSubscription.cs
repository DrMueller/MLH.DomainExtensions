using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models
{
    public class TypeDomainEventSubscription<T> : IDomainEventSubscription
        where T : DomainEvent
    {
        private readonly Action<T> _callback;

        public TypeDomainEventSubscription(Action<T> callback)
        {
            _callback = callback;
            Guard.ObjectNotNull(() => callback);
        }

        public void ExecuteCallback(DomainEvent domainEvent)
        {
            _callback(domainEvent as T);
        }
    }
}