using FluentAssertions;
using game_store.Application.GameOperations.Commands.DeleteGame;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GameOperations.Commands.DeleteGame {
	public class DeleteGameCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public DeleteGameCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistGameIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteGameCommand command = new DeleteGameCommand(context);
			command.GameID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Game could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Game_ShouldBeDeleted() {
			DeleteGameCommand command = new DeleteGameCommand(context);
			command.GameID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Game? result_game = context.Games.SingleOrDefault(g => g.ID == command.GameID);
			result_game.Should().BeNull();
		}
	}
}