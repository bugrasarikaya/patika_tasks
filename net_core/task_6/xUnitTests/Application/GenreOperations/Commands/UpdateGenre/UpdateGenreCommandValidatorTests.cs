using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.UpdateGenre;
using xUnitTests.TestSetup;
using static movie_store.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
namespace xUnitTests.Application.GenreOperations.Commands.UpdateGenre {
	public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("S")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name) {
			UpdateGenreCommand command = new UpdateGenreCommand(null);
			command.Model = new UpdateGenreModel() { Name = name };
			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateGenreCommand command = new UpdateGenreCommand(null);
			command.GenreID = 1;
			command.Model = new UpdateGenreModel() { Name = "Sci-Fi" };
			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}