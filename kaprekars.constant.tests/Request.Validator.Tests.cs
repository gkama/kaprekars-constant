using Xunit;
using FluentValidation;
using FluentAssertions;

using kaprekars.constant.data;

namespace kaprekars.constant.tests;

public class ReuqestValidatorTests
{
    private readonly IValidator<Request> _validator;

    public ReuqestValidatorTests()
    {
        _validator = new RequestValidator();
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("1495")]
    [InlineData("8082")]
    [InlineData("8532")]
    public void RequestValidator_ShouldBeValid(string number)
    {
        // Arrange
        var request = new Request
        {
            Number = number
        };

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("12345")]
    [InlineData("123a")]
    [InlineData("1234ab")]
    [InlineData("1111")]
    [InlineData("0000")]
    public void RequestValidator_ShouldBeInvalid(string number)
    {
        // Arrange
        var request = new Request
        {
            Number = number
        };

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
    }
}