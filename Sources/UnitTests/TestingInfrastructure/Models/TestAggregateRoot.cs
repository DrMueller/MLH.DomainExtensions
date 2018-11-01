using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Models
{
    public class TestAggregateRoot : AggregateRoot<long>
    {
        public TestAggregateRoot(long id) : base(id)
        {
        }
    }
}