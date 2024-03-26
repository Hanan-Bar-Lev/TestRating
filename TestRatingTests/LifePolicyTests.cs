using System;
using TestRating.Models;
using Xunit;

public class LifePolicyTests
{
    [Fact]
    public void Rate_ShouldReturnZeroWhenAmountIsNotValid()
    {
        // Arrange
        var policy = new LifePolicy
        {
            IsSmoker = false,
            Amount = 0, // Invalid amount
            DateOfBirth = new DateTime(1990, 1, 1)
        };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(0, rating);
    }

    [Theory]
    [InlineData(false, 100, 1990, 1, 1, 17)]
    [InlineData(true, 100, 1990, 1, 1, 34)]
    [InlineData(false, 50, 1980, 1, 1, 11)]
    [InlineData(true, 50, 1980, 1, 1, 22)]
    public void Rate_ShouldCalculateCorrectRatingBasedOnInputs(
        bool isSmoker,
        decimal amount,
        int birthYear,
        int birthMonth,
        int birthDay,
        decimal expected)
    {
        // Arrange
        var policy = new LifePolicy
        {
            IsSmoker = isSmoker,
            Amount = amount,
            DateOfBirth = new DateTime(birthYear, birthMonth, birthDay)
        };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(expected, rating);
    }
}