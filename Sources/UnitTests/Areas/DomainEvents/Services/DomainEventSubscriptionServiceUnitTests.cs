using System.Linq;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services.Implementation;
using Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainEvents.TestModels;
using NUnit.Framework;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Areas.DomainEvents.Services
{
    [TestFixture]
    public class DomainEventSubscriptionServiceUnitTests
    {
        private DomainEventSubscriptionService _sut;

        [Test]
        public void RegisteringBroadcastedSubscription_SubscribesType()
        {
            // Arrange
            var subscription = new BroadcastDomainEventSubscription(
                ev =>
                {
                });

            // Act
            _sut.Register(subscription);

            // Assert
            Assert.AreEqual(1, _sut.Subscriptions.Count);
            Assert.AreEqual(subscription, _sut.Subscriptions.Single());
        }

        [Test]
        public void RegisteringDomainEventByType_SubscribesType()
        {
            // Arrange
            var subscription = new TypeDomainEventSubscription<TestDomainEvent>(
                ev =>
                {
                });

            // Act
            _sut.Register(subscription);

            // Assert
            Assert.AreEqual(1, _sut.Subscriptions.Count);
            Assert.AreEqual(subscription, _sut.Subscriptions.Single());
        }

        [SetUp]
        public void SetUp()
        {
            _sut = new DomainEventSubscriptionService();
        }
    }
}