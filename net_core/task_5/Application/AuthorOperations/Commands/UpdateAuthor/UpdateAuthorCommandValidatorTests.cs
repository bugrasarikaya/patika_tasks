using FluentAssertions;
using task_4.Application.AuthorOperations.Commands.CreateAuthor;
using task_4.Application.AuthorOperations.Commands.UpdateAuthor;
using task_5.TestSetup;
using static task_4.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace task_5.Application.AuthorOperations.Commands.UpdateAuthor {
	public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("A", "S")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname) {
			UpdateAuthorCommand command = new UpdateAuthorCommand(null);
			command.Model = new UpdateAuthorModel() { Name = name, Surname = surname, DateofBirth = DateTime.Now.Date.AddYears(-1) };
			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError() {
			UpdateAuthorCommand command = new UpdateAuthorCommand(null);
			command.Model = new UpdateAuthorModel() { Name = "Andrzej", Surname = "Sapkowski", DateofBirth = DateTime.Now.Date };
			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateAuthorCommand command = new UpdateAuthorCommand(null);
			command.AuthorID = 2;
			command.Model = new UpdateAuthorModel() { Name = "Andrzej", Surname = "Sapkowski", DateofBirth = new DateTime(1946, 06, 21) };
			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}