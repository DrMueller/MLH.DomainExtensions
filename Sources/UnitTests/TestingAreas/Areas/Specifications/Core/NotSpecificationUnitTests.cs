using Mmu.Mlh.DomainExtensions.Areas.Specifications.Core;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.DomainModeling.TestModels;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Specifications;
using NUnit.Framework;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingAreas.Areas.Specifications.Core
{
    [TestFixture]
    public class NotSpecificationUnitTests
    {
        [Test]
        public void False_Equals_True()
        {
            // Arrange
            var falseSpec = new GenericSpecification(false);
            var notSpec = new NotSpecification<TestAggregateRoot, long>(falseSpec);

            // Act
            var actualSpecResult = notSpec.IsSatisfiedBy(null);

            // Assert
            Assert.True(actualSpecResult);
        }

        [Test]
        public void True_Equals_False()
        {
            // Arrange
            var trueSpec = new GenericSpecification(true);
            var notSpec = new NotSpecification<TestAggregateRoot, long>(trueSpec);

            // Act
            var actualSpecResult = notSpec.IsSatisfiedBy(null);

            // Assert
            Assert.IsFalse(actualSpecResult);
        }
    }
}