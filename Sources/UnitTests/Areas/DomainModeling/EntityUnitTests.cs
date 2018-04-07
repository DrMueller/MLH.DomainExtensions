using Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainModeling.TestModels;
using NUnit.Framework;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Areas.DomainModeling
{
    [TestFixture]
    public class EntityUnitTests
    {
        [Test]
        public void ComparingEntities_WithDifferentIds_ReturnAreNotEqual()
        {
            // Arrange
            var aggregateRoot1 = new TestEntity("1") { StringProperty1 = "Test1234" };
            var aggregateRoot2 = new TestEntity("2") { StringProperty1 = "Test1234" };

            // Act
            var actualComparisonResult = aggregateRoot1 == aggregateRoot2;

            // assert
            Assert.That(actualComparisonResult, Is.False);
        }

        [Test]
        public void ComparingEntities_WithEqualIds_ReturnAreEqual()
        {
            // Arrange
            var aggregateRoot1 = new TestEntity("1") { StringProperty1 = "Test1234" };
            var aggregateRoot2 = new TestEntity("1") { StringProperty1 = "Test4321" };

            // Act
            var actualComparisonResult = aggregateRoot1 == aggregateRoot2;

            // assert
            Assert.That(actualComparisonResult, Is.True);
        }
    }
}