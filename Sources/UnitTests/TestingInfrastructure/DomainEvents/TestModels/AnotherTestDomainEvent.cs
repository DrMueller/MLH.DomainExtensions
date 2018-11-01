using Mmu.Mlh.DomainExtensions.Areas.DomainEvents.Models;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.DomainEvents.TestModels
{
    public class AnotherTestDomainEvent : DomainEvent
    {
        public override string Message { get; }

        public AnotherTestDomainEvent(string message)
        {
            Message = message;
        }
    }
}