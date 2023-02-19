using FluentAssertions;
using game_store.Application.GameOperations.Commands.CreateGame;
using xUnitTests.TestSetup;
using static game_store.Application.GameOperations.Commands.CreateGame.CreateGameCommand;
namespace xUnitTests.Application.GameOperations.Commands.CreateGame {
	public class CreateGameCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", 0, 0.0)]
		[InlineData("", 0, 1.0)]
		[InlineData("", 1900, 1.0)]
		[InlineData(" ", 0, 0.0)]
		[InlineData(" ", 0, 1.0)]
		[InlineData(" ", 1900, 1.0)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year, double price) {
			CreateGameCommand command = new CreateGameCommand(null, null);
			command.Model = new CreateGameModel() { Name = name, Year = year, Price = price };
			CreateGameCommandValidator validator = new CreateGameCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateGameCommand command = new CreateGameCommand(null, null);
			command.Model = new CreateGameModel() { Name = "The Witcher 3: Wild Hunt", Year = 2015, Price = 39.99 };
			CreateGameCommandValidator validator = new CreateGameCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}