using Xunit;
using FluentAssertions;

using kaprekars.constant.data;

namespace kaprekars.constant.tests;

public class ExtensionsTests
{
    [Theory]
    [InlineData(1324, 1234)]
    [InlineData(1495, 1459)]
    [InlineData(8082, 0288)]
    [InlineData(8532, 2358)]
    [InlineData(0082, 0028)]
    public void ToAscendingOrder(int inputNumber, int resultNumber)
    {
        // Act
        var result = inputNumber.ToAscendingOrder();

        // Assert
        result.Should().Be(resultNumber);
    }

    [Theory]
    [InlineData(1324, 4321)]
    [InlineData(1495, 9541)]
    [InlineData(3474, 7443)]
    [InlineData(8082, 8820)]
    [InlineData(8532, 8532)]
    [InlineData(0082, 0082)]
    public void ToDescendingOrder(int inputNumber, int resultNumber)
    {
        // Act
        var result = inputNumber.ToDescendingOrder();

        // Assert
        result.Should().Be(resultNumber);
    }
}