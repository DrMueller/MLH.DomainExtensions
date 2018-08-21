using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainEvents.TestModels
{
    public class TestDomainEvent : DomainEvent
    {
        public TestDomainEvent(string message) => Message = message;

        public override string Message { get; }
    }
}