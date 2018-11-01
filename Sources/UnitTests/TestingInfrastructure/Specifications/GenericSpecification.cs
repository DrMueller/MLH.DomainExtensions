using System;
using System.Linq.Expressions;
using Mmu.Mlh.DomainExtensions.Areas.Specifications;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.DomainModeling.TestModels;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Specifications
{
    public class GenericSpecification : SpecificationBase<TestAggregateRoot, long>
    {
        private readonly bool _returnsTrue;

        public GenericSpecification(bool returnsTrue)
        {
            _returnsTrue = returnsTrue;
        }

        public override Expression<Func<TestAggregateRoot, bool>> ToExpression()
        {
            return ag => _returnsTrue;
        }
    }
}