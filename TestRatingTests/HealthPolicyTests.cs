using System;
using TestRating.Models;
using Xunit;

public class HealthPolicyTests
{
    [Fact]
    public void Rate_ShouldReturnZeroWhenGenderIsNull()
    {
        // Arrange
        var policy = new HealthPolicy { Deductible = 500 };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(0, rating);
    }

    [Theory]
    [InlineData("Male", 400, 1000)]
    [InlineData("Male", 600, 900)]
    [InlineData("Female", 700, 1100)]
    [InlineData("Female", 900, 1000)]
    public void Rate_ShouldReturnCorrectRatingForGivenGenderAndDeductible(string gender, decimal deductible, decimal expected)
    {
        // Arrange
        var policy = new HealthPolicy { Gender = gender, Deductible = deductible };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(expected, rating);
    }
}