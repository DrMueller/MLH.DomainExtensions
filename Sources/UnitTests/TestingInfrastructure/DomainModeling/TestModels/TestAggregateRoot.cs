using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.DomainModeling.TestModels
{
    public class TestAggregateRoot : AggregateRoot<long>
    {
        public TestAggregateRoot(long id) : base(id)
        {
        }
    }
}