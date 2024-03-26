using System;
using TestRating.Models;
using Xunit;

public class TravelPolicyTests
{
    [Fact]
    public void Rate_ShouldReturnZeroWhenCountryIsNull()
    {
        // Arrange
        var policy = new TravelPolicy { Days = 10 };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(0, rating);
    }

    [Fact]
    public void Rate_ShouldReturnZeroWhenDaysIsOutOfRange()
    {
        // Arrange
        var policy = new TravelPolicy { Country = "USA", Days = 200 };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(0, rating);
    }

    [Fact]
    public void Rate_ShouldReturnCorrectRatingForNonItalyCountry()
    {
        // Arrange
        var policy = new TravelPolicy { Country = "USA", Days = 10 };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(25, rating);
    }

    [Fact]
    public void Rate_ShouldReturnCorrectRatingForItalyCountry()
    {
        // Arrange
        var policy = new TravelPolicy { Country = "Italy", Days = 10 };

        // Act
        decimal rating = policy.Rate();

        // Assert
        Assert.Equal(75, rating);
    }
}