using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.DeleteGenre;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Commands.DeleteGenre {
	public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int genre_ID) {
			DeleteGenreCommand command = new DeleteGenreCommand(null);
			command.GenreID = genre_ID;
			DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int genre_ID) {
			DeleteGenreCommand command = new DeleteGenreCommand(null);
			command.GenreID = genre_ID;
			DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}