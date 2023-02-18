using FluentAssertions;
using movie_store.Application.MovieOperations.Commands.DeleteMovie;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.MovieOperations.Commands.DeleteMovie {
	public class DeleteMovieCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int movie_ID) {
			DeleteMovieCommand command = new DeleteMovieCommand(null);
			command.MovieID = movie_ID;
			DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int movie_ID) {
			DeleteMovieCommand command = new DeleteMovieCommand(null);
			command.MovieID = movie_ID;
			DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}