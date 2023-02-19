using FluentAssertions;
using game_store.Application.GameOperations.Commands.DeleteGame;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GameOperations.Commands.DeleteGame {
	public class DeleteGameCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int game_ID) {
			DeleteGameCommand command = new DeleteGameCommand(null);
			command.GameID = game_ID;
			DeleteGameCommandValidator validator = new DeleteGameCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int game_ID) {
			DeleteGameCommand command = new DeleteGameCommand(null);
			command.GameID = game_ID;
			DeleteGameCommandValidator validator = new DeleteGameCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}