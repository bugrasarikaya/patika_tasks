using FluentAssertions;
using movie_store.Application.AuthorOperations.Commands.CreateAuthor;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
namespace xUnitTests.Application.AuthorOperations.Commands.CreateAuthor {
	public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("A", "S")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname) {
			CreateAuthorCommand command = new CreateAuthorCommand(null, null);
			command.Model = new CreateAuthorModel() { Name = name, Surname = surname, DateofBirth = DateTime.Now.Date.AddYears(-1) };
			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError() {
			CreateAuthorCommand command = new CreateAuthorCommand(null, null);
			command.Model = new CreateAuthorModel() { Name = "Andrzej", Surname = "Sapkowski", DateofBirth = DateTime.Now.Date };
			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateAuthorCommand command = new CreateAuthorCommand(null, null);
			command.Model = new CreateAuthorModel() { Name = "Andrzej", Surname = "Sapkowski", DateofBirth = new DateTime(1946, 06, 21) };
			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}