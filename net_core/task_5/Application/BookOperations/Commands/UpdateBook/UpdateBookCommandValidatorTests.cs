using FluentAssertions;
using task_4.Application.BookOperations.Commands.UpdateBook;
using task_5.TestSetup;
namespace task_5.Application.BookOperations.Commands.UpdateBook {
	public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", 2, 2)]
		[InlineData(" ", 2, 2)]
		[InlineData("Lor", 2, 2)]
		[InlineData("Lord of The Rings", 1, 1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string title, int genreID, int authorID) {
			UpdateBookCommand command = new UpdateBookCommand(null);
			command.Model = new UpdateBookModel() { Title = title, GenreID = genreID, AuthorID = authorID };
			UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateBookCommand command = new UpdateBookCommand(null);
			command.BookID = 2;
			command.Model = new UpdateBookModel() { Title = "Lord of The Rings", GenreID = 1, AuthorID = 1 };
			UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}