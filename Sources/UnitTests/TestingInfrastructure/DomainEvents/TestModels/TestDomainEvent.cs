using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.DomainEvents.TestModels
{
    public class TestDomainEvent : DomainEvent
    {
        public override string Message { get; }

        public TestDomainEvent(string message)
        {
            Message = message;
        }
    }
}