using FluentAssertions;
using game_store.Application.GameOperations.Commands.UpdateGame;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.GameOperations.Commands.UpdateGame.UpdateGameCommand;
namespace xUnitTests.Application.GameOperations.Commands.UpadteGame {
	public class UpdateGameCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public UpdateGameCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistGameIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateGameCommand command = new UpdateGameCommand(context);
			command.GameID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Game could not be found.");
		}
		[Fact]
		public void WhenNotExistDeveloperIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateGameCommand command = new UpdateGameCommand(context);
			command.GameID = 1;
			command.Model = new UpdateGameModel() { Name = "The Witcher 3: Wild Hunt", Year = 2015, Price = 39.99, DeveloperIDs = new List<int>() { 0 }, PublisherIDs = new List<int>() { 1 } };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Developer could not be found.");
		}
		[Fact]
		public void WhenNotExistPublisherIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateGameCommand command = new UpdateGameCommand(context);
			command.GameID = 1;
			command.Model = new UpdateGameModel() { Name = "The Witcher 3: Wild Hunt", Year = 2015, Price = 39.99, DeveloperIDs = new List<int>() { 1 }, PublisherIDs = new List<int>() { 0 } };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Publisher could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Game_ShouldBeUpdated() {
			UpdateGameCommand command = new UpdateGameCommand(context);
			UpdateGameModel model = new UpdateGameModel() { Name = "The Witcher 3: Wild Hunt", Year = 2015, Price = 39.99, DeveloperIDs = new List<int>() { 1 }, PublisherIDs = new List<int>() { 1 } };
			command.Model = model;
			command.GameID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Game? game = context.Games.SingleOrDefault(g => g.ID == command.GameID);
			game.Should().NotBeNull();
			List<GameDeveloper>? list_game_developer = context.GameDevelopers.Where(ma => ma.GameID == command.GameID).ToList();
			list_game_developer.Should().NotBeNull();
			list_game_developer.Count.Should().Be(command.Model.DeveloperIDs.Count);
			for (int i = 0; i < list_game_developer.Count; i++) list_game_developer[0].DeveloperID.Should().Be(command.Model.DeveloperIDs[i]);
			List<GamePublisher>? list_game_publisher = context.GamePublishers.Where(ma => ma.GameID == command.GameID).ToList();
			list_game_publisher.Should().NotBeNull();
			list_game_publisher.Count.Should().Be(command.Model.PublisherIDs.Count);
			for (int i = 0; i < list_game_publisher.Count; i++) list_game_publisher[0].PublisherID.Should().Be(command.Model.PublisherIDs[i]);
		}
	}
}