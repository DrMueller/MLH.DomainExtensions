using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services;
using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Services.Implementation;
using Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainEvents.TestModels;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Areas.DomainEvents.Services
{
    [TestFixture]
    public class DomainEventPublishingServiceUnitTests
    {
        private Mock<IDomainEventSubscriptionService> _subscriptionServiceMock;

        private DomainEventPublishingService _sut;

        [Test]
        public void PublishingDomainEvent_With1RegisteredAndBroadcastingTypes_PublishesTwoBothSubscriptions()
        {
            // Arrange
            var testDomainCbWasCalled = false;
            var broadcastCbWasCalled = false;

            var subscripctions = new List<IDomainEventSubscription>
            {
                new TypeDomainEventSubscription<TestDomainEvent>(domainEvent => testDomainCbWasCalled = true),
                new BroadcastDomainEventSubscription(domainEvent => broadcastCbWasCalled = true)
            };

            _subscriptionServiceMock.Setup(s => s.Subscriptions).Returns(subscripctions);

            // Act
            _sut.Publish(new TestDomainEvent(string.Empty));

            // Assert
            Assert.IsTrue(testDomainCbWasCalled);
            Assert.IsTrue(broadcastCbWasCalled);
        }

        [Test]
        public void PublishingDomainEvent_With1RegisteredTypes_PublishesOnlyToRegisteredTypeSubscription()
        {
            // Arrange
            var testDomainCbWasCalled = false;
            var anotherTestDomainCbWasCalled = false;

            var subscripctions = new List<IDomainEventSubscription>
            {
                new TypeDomainEventSubscription<TestDomainEvent>(domainEvent => testDomainCbWasCalled = true),
                new TypeDomainEventSubscription<AnotherTestDomainEvent>(domainEvent => anotherTestDomainCbWasCalled = true)
            };

            _subscriptionServiceMock.Setup(s => s.Subscriptions).Returns(subscripctions);

            // Act
            _sut.Publish(new TestDomainEvent(string.Empty));

            // Assert
            Assert.IsTrue(testDomainCbWasCalled);
            Assert.IsFalse(anotherTestDomainCbWasCalled);
        }

        [SetUp]
        public void SetUp()
        {
            _subscriptionServiceMock = new Mock<IDomainEventSubscriptionService>();
            _sut = new DomainEventPublishingService(_subscriptionServiceMock.Object);
        }
    }
}