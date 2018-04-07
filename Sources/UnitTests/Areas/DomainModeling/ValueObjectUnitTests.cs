﻿using System;
using Mmu.Mlh.DomainExtensions.UnitTests.Infrastructure.DomainModeling.TestModels;
using NUnit.Framework;

namespace Mmu.Mlh.DomainExtensions.UnitTests.Areas.DomainModeling
{
    [TestFixture]
    public class ValueObjectUnitTests
    {
        [Test]
        public void ComparingValueObjects_WithDifferentValues_ReturnAreNotEqual()
        {
            // Arrange
            const string StringValue = "Test1";
            const int IntValue = 3;
            var dateTimeValue1 = new DateTime(2000, 1, 1);
            var dateTimeValue2 = new DateTime(2000, 1, 2);

            var valueObject1 = new TestValueObject(StringValue, IntValue, dateTimeValue1);
            var valueObject2 = new TestValueObject(StringValue, IntValue, dateTimeValue2);

            // Act
            var actualComparisonResult = valueObject1 == valueObject2;

            // assert
            Assert.That(actualComparisonResult, Is.False);
        }

        [Test]
        public void ComparingValueObjects_WithEqualValues_ReturnAreEqual()
        {
            // Arrange
            const string StringValue = "Test1";
            const int IntValue = 3;
            var dateTimeValue = new DateTime(2000, 1, 1);

            var valueObject1 = new TestValueObject(StringValue, IntValue, dateTimeValue);
            var valueObject2 = new TestValueObject(StringValue, IntValue, dateTimeValue);

            // Act
            var actualComparisonResult = valueObject1 == valueObject2;

            // assert
            Assert.That(actualComparisonResult, Is.True);
        }
    }
}