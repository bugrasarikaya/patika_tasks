using FluentAssertions;
using game_store.Application.DeveloperOperations.Commands.DeleteDeveloper;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DeveloperOperations.Commands.DeleteDeveloper {
	public class DeleteDeveloperCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public DeleteDeveloperCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistDeveloperIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteDeveloperCommand command = new DeleteDeveloperCommand(context);
			command.DeveloperID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Developer could not be found.");
		}
		[Fact]
		public void WhenGivenDeveloperIDExistsInGames_InvalidOperationException_ShouldBeReturn() {
			DeleteDeveloperCommand command = new DeleteDeveloperCommand(context);
			command.DeveloperID = 1;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Developer exists in a game.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Developer_ShouldBeDeleted() {
			DeleteDeveloperCommand command = new DeleteDeveloperCommand(context);
			Developer developer = new Developer() { Name = "CD PROJEKT RED", Year = 1994 };
			context.Developers.Add(developer);
			context.SaveChanges();
			command.DeveloperID = developer.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Developer? result_developer = context.Developers.SingleOrDefault(d => d.ID == command.DeveloperID);
			result_developer.Should().BeNull();
		}
	}
}