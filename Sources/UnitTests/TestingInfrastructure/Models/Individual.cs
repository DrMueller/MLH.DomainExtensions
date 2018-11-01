using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Models
{
    public class Individual : AggregateRoot<long>
    {
        public bool IsMale { get; }

        public Individual(long id, bool isMale) : base(id)
        {
            IsMale = isMale;
        }
    }
}