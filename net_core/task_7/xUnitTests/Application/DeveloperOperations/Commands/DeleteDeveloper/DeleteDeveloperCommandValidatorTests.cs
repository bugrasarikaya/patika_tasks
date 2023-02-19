using FluentAssertions;
using game_store.Application.DeveloperOperations.Commands.DeleteDeveloper;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DeveloperOperations.Commands.DeleteDeveloper {
	public class DeleteDeveloperCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int developer_ID) {
			DeleteDeveloperCommand command = new DeleteDeveloperCommand(null);
			command.DeveloperID = developer_ID;
			DeleteDeveloperCommandValidator validator = new DeleteDeveloperCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int developer_ID) {
			DeleteDeveloperCommand command = new DeleteDeveloperCommand(null);
			command.DeveloperID = developer_ID;
			DeleteDeveloperCommandValidator validator = new DeleteDeveloperCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}