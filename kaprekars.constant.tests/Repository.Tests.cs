using System;
using Xunit;
using Xunit.Gherkin.Quick;
using NSubstitute;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using kaprekars.constant.data;
using kaprekars.constant.services;

namespace kaprekars.constant.tests
{
    public class RepositoryTests
    {
        private readonly IRepository _repo;

        public RepositoryTests()
        {
            _repo = new Repository(
                Substitute.For<ILogger<Repository>>(),
                new RequestValidator());
        }

        [Fact]
        public void Repository_WhenILoggerNull_ShouldThrowArgumentNullException()
        {
            // Act
            var builder = () => _ = new Repository(null, Substitute.For<IValidator<Request>>());

            // Assert
            builder.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Repository_WhenIValidatorNull_ShouldThrowArgumentNullException()
        {
            // Act
            var builder = () => _ = new Repository(Substitute.For<ILogger<Repository>>(), null);

            // Assert
            builder.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("8597")]
        [InlineData("5413")]
        [InlineData("6174")]
        public void GetRoutines_IsSuccessful(string num)
        {
            // Arrange
            var req = new Request { Number = num };

            // Act
            var routines = _repo.GetRoutines(req);

            // Assert
            routines.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("12345")]
        [InlineData("123a")]
        [InlineData("1234ab")]
        [InlineData("1111")]
        [InlineData("0000")]
        public void GetRoutines_WhenInvalidNumber_ShouldThrowException(string num)
        {
            // Arrange
            var req = new Request { Number = num };

            // Act
            var builder = () => _ = _repo.GetRoutines(req);

            // Assert
            builder.Should().Throw<ValidationException>();
        }

        [Theory]
        [InlineData("1112")]
        public void GetRoutines_WhenNumberWithNoKaprekarConstat_ShouldThrowApplicationException(string num)
        {
            // Arrange
            var req = new Request { Number = num };

            // Act
            var builder = () => _ = _repo.GetRoutines(req);

            // Assert
            builder.Should().Throw<ApplicationException>();
        }

        [Theory]
        [InlineData("1342", 1234, 4321)]
        [InlineData("1954", 1459, 9541)]
        [InlineData("8082", 0288, 8820)]
        [InlineData("8352", 2358, 8532)]
        [InlineData("0028", 0028, 8200)]
        public void GetRoutine_IsSuccessful(string num, int asc, int desc)
        {
            // Arrange & Act
            var routine = _repo.GetRoutine(num);

            // Assert
            routine.Should().NotBeNull();
            routine.Number.Should().Be(int.Parse(num));
            routine.Ascending.Should().Be(asc);
            routine.Descending.Should().Be(desc);
            routine.Result.Should().Be(desc > asc ? desc - asc : asc - desc);
            routine.Subtraction.Should().Contain(asc.ToString());
            routine.Subtraction.Should().Contain(desc.ToString());
            routine.Subtraction.Should().Contain(routine.Result.ToString());
        }
    }

    [FeatureFile("./Features/RepositoryGetRoutine.feature")]
    public sealed class RepositoryGetRoutine : Feature
    {
        private readonly IRepository _repo;
        private string _num;
        private Routine _routine;

        public RepositoryGetRoutine()
        {
            _repo = new Repository(
                Substitute.For<ILogger<Repository>>(),
                new RequestValidator());
            _num = string.Empty;
             _routine = new Routine();
        }

        [Given(@"I chose a four-digit number with two unique digits (\d+)")]
        public void SetNum(string num)
        {
            _num = num;
        }

        [When(@"I get a routine")]
        public void IGetARoutine()
        {
            _routine = _repo.GetRoutine(_num);
        }

        [Then(@"the ascending number should be (\d+)")]
        public void TheAscendingNumberShouldBe(int asc)
        {
            _routine.Ascending.Should().Be(asc);
        }

        [And(@"the descending number should be (\d+)")]
        public void TheDescendingNumberShouldBe(int desc)
        {
            _routine.Descending.Should().Be(desc);
        }

        [And(@"the result number should be (\d+)")]
        public void TheResultNumberShouldBe(int res)
        {
            _routine.Result.Should().Be(res);
        }
    }
}
