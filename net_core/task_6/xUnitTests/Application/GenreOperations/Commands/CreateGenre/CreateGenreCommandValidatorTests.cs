using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.CreateGenre;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
namespace xUnitTests.Application.GenreOperations.Commands.CreateGenre {
	public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("Thr")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name) {
			CreateGenreCommand command = new CreateGenreCommand(null);
			command.Model = new CreateGenreModel() { Name = name };
			CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateGenreCommand command = new CreateGenreCommand(null);
			command.Model = new CreateGenreModel() { Name = "Thriller" };
			CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}