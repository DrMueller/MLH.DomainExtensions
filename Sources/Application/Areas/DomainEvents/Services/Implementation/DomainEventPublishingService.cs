﻿using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services.Implementation
{
    public class DomainEventPublishingService : IDomainEventPublishingService
    {
        private readonly IDomainEventSubscriptionService _subscriptionService;

        public DomainEventPublishingService(IDomainEventSubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        public void Publish<T>(T domainEvent) where T : DomainEvent
        {
            GetSubscriptions<T>().ForEach(sub => sub.ExecuteCallback(domainEvent));
        }

        private IEnumerable<IDomainEventSubscription> GetSubscriptions<T>() where T : DomainEvent
        {
            var targetSubscriptions = _subscriptionService
                .Subscriptions
                .OfType<TypeDomainEventSubscription<T>>()
                .Cast<IDomainEventSubscription>();

            var broadCastSubscrptions = _subscriptionService
                .Subscriptions
                .OfType<BroadcastDomainEventSubscription>()
                .Cast<IDomainEventSubscription>();

            var result = targetSubscriptions.Concat(broadCastSubscrptions).ToList();
            return result;
        }
    }
}