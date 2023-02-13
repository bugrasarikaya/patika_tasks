using FluentAssertions;
using task_4.Application.GenreOperations.Commands.UpdateGenre;
using task_5.TestSetup;
namespace task_5.Application.GenreOperations.Commands.UpdateGenre {
	public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("Thr")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name) {
			UpdateGenreCommand command = new UpdateGenreCommand(null);
			command.Model = new UpdateGenreModel() { Name = name, IsActive = true };
			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateGenreCommand command = new UpdateGenreCommand(null);
			command.GenreID = 2;
			command.Model = new UpdateGenreModel() { Name = "Thriller", IsActive = true };
			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}