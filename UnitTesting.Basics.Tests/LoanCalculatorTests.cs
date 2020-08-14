using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTesting.Basics.Tests
{
    public class LoanCalculatorTests
    {
        [Theory]
        [InlineData(10000, 15000)]
        [InlineData(40000, 75000)]
        [InlineData(60000, 150000)]
        [InlineData(101000, 500000)]
        [InlineData(200000, 500000)]
        [InlineData(400000, 500000)]
        public void GetLoanAmount_WithValidInput_ReturnsValidResult(int memberContribution, int expectedResult)
        {
            // Arrange
            var sut = new LoanCalculator();

            // Act
            var result = sut.GetLoanAmount(memberContribution);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0.9, 10000)]
        [InlineData(1.9, 35000)]
        [InlineData(4.9, 100000)]
        [InlineData(6, 250000)]
        public void GetBoostLoanAmount_WithValidInput_ReturnsValidResult(double memberTerm, int expectedResult)
        {
            // Arrange
            var sut = new LoanCalculator();

            // Act
            var result = sut.GetBoostLoanAmount(memberTerm);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
