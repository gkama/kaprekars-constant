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
        [InlineData("1342", "1234", "4321")]
        [InlineData("1954", "1459", "9541")]
        [InlineData("8082", "288", "8820")]
        [InlineData("8352", "2358", "8532")]
        [InlineData("0028", "28", "8200")]
        public void GetRoutine_IsSuccessful(string num, string asc, string desc)
        {
            // Arrange & Act
            var routine = _repo.GetRoutine(num);

            // Assert
            routine.Should().NotBeNull();
            routine.Number.Should().Be(num);
            routine.Ascending.Should().Be(int.Parse(asc).ToString());
            routine.Descending.Should().Be(int.Parse(desc).ToString());
            routine.Result.Should().Be(string.Format("{0:0000}", int.Parse(desc) > int.Parse(asc) ? int.Parse(desc) - int.Parse(asc) : int.Parse(asc) - int.Parse(desc)));
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

        [Given(@"I chose a four-digit number with two unique digits ""(\w+?)""")]
        public void SetNum(string num)
        {
            _num = num;
        }

        [When(@"I get a routine")]
        public void IGetARoutine()
        {
            _routine = _repo.GetRoutine(_num);
        }

        [Then(@"the ascending number should be ""(\w+?)""")]
        public void TheAscendingNumberShouldBe(string asc)
        {
            _routine.Ascending.Should().Be(asc);
        }

        [And(@"the descending number should be ""(\w+?)""")]
        public void TheDescendingNumberShouldBe(string desc)
        {
            _routine.Descending.Should().Be(desc);
        }

        [And(@"the result number should be ""(\w+?)""")]
        public void TheResultNumberShouldBe(string res)
        {
            _routine.Result.Should().Be(res);
        }
    }
}
