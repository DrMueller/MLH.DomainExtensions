using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services
{
    public interface IDomainEventSubscriptionService
    {
        IReadOnlyCollection<IDomainEventSubscription> Subscriptions { get; }

        void Register(IDomainEventSubscription subscription);
    }
}