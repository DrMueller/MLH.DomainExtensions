using Mmu.Mlh.DomainExtensions.Areas.Specifications.Core;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Models;
using Mmu.Mlh.DomainExtensions.UnitTests.TestingInfrastructure.Specifications;
using NUnit.Framework;

namespace Mmu.Mlh.DomainExtensions.UnitTests.TestingAreas.Areas.Specifications
{
    [TestFixture]
    public class SpecificationBaseUnitTests
    {
        [Test]
        public void And_CreatesAndSpecification()
        {
            // Arrange
            var spec = new GenericSpecification(false);
            var anotherSpec = new GenericSpecification(true);

            // Act
            var actualSpec = spec.And(anotherSpec);

            // Assert
            Assert.That(actualSpec, Is.TypeOf<AndSpecification<TestingInfrastructure.DomainModeling.TestModels.TestAggregateRoot, long>>());
        }

        [Test]
        public void CheckingIfSatisfied_ChecksExpression()
        {
            // Arrange
            var spec = new IndividualIsFemaleSpecification();
            var maleIndividual = new Individual(-1, true);

            // Act
            var actualSpecResult = spec.IsSatisfiedBy(maleIndividual);

            // Assert
            Assert.IsTrue(spec.ExpressionWasCalled);
            Assert.IsFalse(actualSpecResult);
        }

        [Test]
        public void Not_CreatesNotSpecification()
        {
            // Arrange
            var spec = new GenericSpecification(false);

            // Act
            var actualSpec = spec.Not();

            // Assert
            Assert.That(actualSpec, Is.TypeOf<NotSpecification<TestingInfrastructure.DomainModeling.TestModels.TestAggregateRoot, long>>());
        }

        [Test]
        public void Or_CreatesOrSpecification()
        {
            // Arrange
            var spec = new GenericSpecification(false);
            var anotherSpec = new GenericSpecification(true);

            // Act
            var actualSpec = spec.Or(anotherSpec);

            // Assert
            Assert.That(actualSpec, Is.TypeOf<OrSpecification<TestingInfrastructure.DomainModeling.TestModels.TestAggregateRoot, long>>());
        }
    }
}