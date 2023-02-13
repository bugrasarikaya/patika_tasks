using FluentAssertions;
using task_4.Application.GenreOperations.Commands.DeleteGenre;
using task_4.Entities;
using task_5.TestSetup;
namespace task_5.Application.GenreOperations.Commands.DeleteGenre {
	public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int GenreID) {
			DeleteGenreCommand command = new DeleteGenreCommand(null);
			command.GenreID = GenreID;
			DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int GenreID) {
			DeleteGenreCommand command = new DeleteGenreCommand(null);
			command.GenreID = GenreID;
			DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}