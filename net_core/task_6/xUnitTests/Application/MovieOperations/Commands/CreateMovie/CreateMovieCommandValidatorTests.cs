using FluentAssertions;
using movie_store.Application.MovieOperations.Commands.CreateMovie;
using xUnitTests.TestSetup;
using static movie_store.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
namespace xUnitTests.Application.MovieOperations.Commands.CreateMovie {
	public class CreateMovieCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", 0, 0.0)]
		[InlineData("", 0, 1.0)]
		[InlineData("", 1900, 1.0)]
		[InlineData(" ", 0, 0.0)]
		[InlineData(" ", 0, 1.0)]
		[InlineData(" ", 1900, 1.0)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year, double price) {
			CreateMovieCommand command = new CreateMovieCommand(null, null);
			command.Model = new CreateMovieModel() { Name = name, Year = year, Price = price };
			CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateMovieCommand command = new CreateMovieCommand(null, null);
			command.Model = new CreateMovieModel() { Name = "Matrix", Year = 1999, Price = 17.99 };
			CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}