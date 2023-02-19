using FluentAssertions;
using game_store.Application.GameOperations.Commands.UpdateGame;
using xUnitTests.TestSetup;
using static game_store.Application.GameOperations.Commands.UpdateGame.UpdateGameCommand;
namespace xUnitTests.Application.GameOperations.Commands.UpdateGame {
	public class UpdateGameCommandValidatorTests : IClassFixture<CommonTestFixture> {
		public static IEnumerable<object[]> Data() {
			yield return new object[] { "", 0, 0.0, new List<int>(), new List<int>() };
			yield return new object[] { " ", 0, 1.0, new List<int>(), new List<int>() };
			yield return new object[] { " ", 1900, 1.0, new List<int>() { 1 }, new List<int>() { 1 } };
		}
		[Theory]
		[MemberData(nameof(Data))]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year, double price, List<int> list_developer_ID, List<int> list_publisher_ID) {
			UpdateGameCommand command = new UpdateGameCommand(null);
			command.Model = new UpdateGameModel() { Name = name, Year = year, Price = price, DeveloperIDs = list_developer_ID, PublisherIDs = list_publisher_ID };
			UpdateGameCommandValidator validator = new UpdateGameCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateGameCommand command = new UpdateGameCommand(null);
			command.GameID = 1;
			command.Model = new UpdateGameModel() { Name = "The Witcher 3: Wild Hunt", Year = 2015, Price = 39.99, DeveloperIDs = new List<int>() { 1 }, PublisherIDs = new List<int>() { 1 } };
			UpdateGameCommandValidator validator = new UpdateGameCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}