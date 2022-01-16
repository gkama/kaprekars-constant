using Xunit;
using FluentAssertions;

using kaprekars.constant.data;

namespace kaprekars.constant.tests
{
    public class RoutineTests
    {
        [Theory]
        [InlineData(1342, 1234, 4321)]
        [InlineData(1954, 1459, 9541)]
        [InlineData(8082, 0288, 8820)]
        [InlineData(8352, 2358, 8532)]
        [InlineData(0028, 0028, 0082)]
        public void Routine_IsSuccessful(
            int number,
            int ascending,
            int descending)
        {
            // Arrange & Act
            var routine = new Routine(number);

            // Assert
            routine.Should().NotBeNull();
            routine.Ascending.Should().Be(ascending);
            routine.Descending.Should().Be(descending);
            routine.Result.Should().Be(ascending - descending);
            routine.Subtraction.Should().Contain(ascending.ToString());
            routine.Subtraction.Should().Contain(descending.ToString());
            routine.Subtraction.Should().Contain(routine.Result.ToString());
        }
    }
}
