using Xunit;
using FluentAssertions;

using kaprekars.constant.data;

namespace kaprekars.constant.tests;

public class ReuqestValidatorTests
{
    private readonly IValidator<ReuqestValidatorTests> _validator;
    public ReuqestValidatorTests()
    {
        _validator = new RequestValidator();
    }

    [Theory]
    [InlineData("1234")]
    public void RequestValidator_IsSuccessful(string number)
    {
        // Arrange
        var request = new Request
        {
            Number = number
        };

        // Act
        var result = _validator.Validate(request);

        // Assert
    }
}