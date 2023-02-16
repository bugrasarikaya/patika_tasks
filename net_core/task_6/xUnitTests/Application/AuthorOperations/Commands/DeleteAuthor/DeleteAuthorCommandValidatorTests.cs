using FluentAssertions;
using movie_store.Application.AuthorOperations.Commands.DeleteAuthor;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.AuthorOperations.Commands.DeleteAuthor {
	public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int AuthorID) {
			DeleteAuthorCommand command = new DeleteAuthorCommand(null);
			command.AuthorID = AuthorID;
			DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int AuthorID) {
			DeleteAuthorCommand command = new DeleteAuthorCommand(null);
			command.AuthorID = AuthorID;
			DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}