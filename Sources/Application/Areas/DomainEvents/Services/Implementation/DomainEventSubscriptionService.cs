﻿using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services.Implementation
{
    internal class DomainEventSubscriptionService : IDomainEventSubscriptionService
    {
        private readonly List<IDomainEventSubscription> _subscriptions = new List<IDomainEventSubscription>();
        public IReadOnlyCollection<IDomainEventSubscription> Subscriptions => _subscriptions;

        public void Register(IDomainEventSubscription subscription)
        {
            _subscriptions.Add(subscription);
        }
    }
}