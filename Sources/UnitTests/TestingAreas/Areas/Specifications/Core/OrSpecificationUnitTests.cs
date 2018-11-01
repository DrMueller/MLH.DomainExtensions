using Mmu.Mlh.DomainExtensions.Areas.Specifications.Core;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.DomainModeling.TestModels;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Specifications;
using NUnit.Framework;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingAreas.Areas.Specifications.Core
{
    [TestFixture]
    public class OrSpecificationUnitTests
    {
        [Test]
        public void LeftFalse_RightFalse_EqualsFalse()
        {
            // Arrange
            var falseSpec = new GenericSpecification(false);
            var orSpec = new OrSpecification<TestAggregateRoot, long>(falseSpec, falseSpec);

            // Act
            var actualSpecResult = orSpec.ToExpression().Compile()(null);

            // Assert
            Assert.IsFalse(actualSpecResult);
        }

        [Test]
        public void LeftFalse_RightTrue_EqualsTrue()
        {
            // Arrange
            var falseSpec = new GenericSpecification(false);
            var trueSpec = new GenericSpecification(true);
            var orSpec = new OrSpecification<TestAggregateRoot, long>(falseSpec, trueSpec);

            // Act
            var actualSpecResult = orSpec.ToExpression().Compile()(null);

            // Assert
            Assert.IsTrue(actualSpecResult);
        }

        [Test]
        public void LeftTrue_RightFalse_EqualsTrue()
        {
            // Arrange
            var falseSpec = new GenericSpecification(false);
            var trueSpec = new GenericSpecification(true);
            var orSpec = new OrSpecification<TestAggregateRoot, long>(trueSpec, falseSpec);

            // Act
            var actualSpecResult = orSpec.ToExpression().Compile()(null);

            // Assert
            Assert.IsTrue(actualSpecResult);
        }

        [Test]
        public void LeftTrue_RightTrue_EqualsTrue()
        {
            // Arrange
            var trueSpec = new GenericSpecification(true);
            var orSpec = new OrSpecification<TestAggregateRoot, long>(trueSpec, trueSpec);

            // Act
            var actualSpecResult = orSpec.IsSatisfiedBy(null);

            // Assert
            Assert.IsTrue(actualSpecResult);
        }
    }
}