using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainEvents.TestModels
{
    public class AnotherTestDomainEvent : DomainEvent
    {
        public AnotherTestDomainEvent(string message) => Message = message;

        public override string Message { get; }
    }
}