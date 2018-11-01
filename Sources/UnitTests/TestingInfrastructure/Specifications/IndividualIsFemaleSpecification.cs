using System;
using System.Linq.Expressions;
using Mmu.Mlh.DomainExtensions.Areas.Specifications;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Models;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Specifications
{
    public class IndividualIsFemaleSpecification : SpecificationBase<Individual, long>
    {
        public bool ExpressionWasCalled { get; private set; }

        public override Expression<Func<Individual, bool>> ToExpression()
        {
            ExpressionWasCalled = true;
            return ind => !ind.IsMale;
        }
    }
}