using FluentAssertions;
using task_4.Application.BookOperations.Commands.CreateBook;
using task_4.Entities;
using task_5.TestSetup;
using static task_4.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
namespace task_5.Application.BookOperations.Commands.CreateBook {
	public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("Lord of The Rings", 0, 0, 0)]
		[InlineData("Lord of The Rings", 0, 1, 1)]
		[InlineData("Lord of The Rings", 100, 0, 0)]
		[InlineData("", 0, 0, 0)]
		[InlineData("", 100, 1, 0)]
		[InlineData("", 0, 1, 0)]
		[InlineData("Lor", 100, 1, 0)]
		[InlineData("Lord", 100, 0, 0)]
		[InlineData("Lord", 0, 1, 1)]
		[InlineData(" ", 100, 1, 1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string title, int pageCount, int genreID, int authorID) {
			CreateBookCommand command = new CreateBookCommand(null, null);
			command.Model = new CreateBookModel() { Title = title, PageCount = pageCount, PublishDate = DateTime.Now.Date.AddYears(-1), GenreID = genreID, AuthorID = authorID };
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError() {
			CreateBookCommand command = new CreateBookCommand(null, null);
			command.Model = new CreateBookModel() { Title = "Lord of The Rings", PageCount = 100, PublishDate = DateTime.Now.Date, GenreID = 1, AuthorID = 1 };
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateBookCommand command = new CreateBookCommand(null, null);
			command.Model = new CreateBookModel() { Title = "Lord of The Rings", PageCount = 100, PublishDate = DateTime.Now.Date.AddYears(-2), GenreID = 1, AuthorID = 1 };
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}