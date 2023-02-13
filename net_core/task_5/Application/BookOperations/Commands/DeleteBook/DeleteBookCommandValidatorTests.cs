using FluentAssertions;
using task_4.Application.BookOperations.Commands.DeleteBook;
using task_4.Entities;
using task_5.TestSetup;
namespace task_5.Application.BookOperations.Commands.DeleteBook {
	public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int bookID) {
			DeleteBookCommand command = new DeleteBookCommand(null);
			command.BookID = bookID;
			DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int bookID) {
			DeleteBookCommand command = new DeleteBookCommand(null);
			command.BookID = bookID;
			DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}