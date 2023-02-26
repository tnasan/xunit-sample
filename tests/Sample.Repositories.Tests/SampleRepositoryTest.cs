using FluentAssertions;

namespace Sample.Repositories.Tests;

public class SampleRepositoryTest
{
    [Theory]
    [InlineData(-1, double.NegativeInfinity)]
    [InlineData(0, double.NaN)]
    [InlineData(1, double.PositiveInfinity)]
    public async Task SampleRepository_Divide_ZeroDividerShouldReturnInfinite(double dividend, double quotient)
    {
        // Assume
        var sampleRepository = new SampleRepository();

        // Act
        var result = await sampleRepository.Divide(dividend, 0);

        // Assert
        result.Should().Be(quotient);
    }
}