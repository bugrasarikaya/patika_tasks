using FluentAssertions;
using game_store.Application.PublisherOperations.Commands.DeletePublisher;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.PublisherOperations.Commands.DeletePublisher {
	public class DeletePublisherCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public DeletePublisherCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistPublisherIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeletePublisherCommand command = new DeletePublisherCommand(context);
			command.PublisherID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Publisher could not be found.");
		}
		[Fact]
		public void WhenGivenPublisherIDExistsInGames_InvalidOperationException_ShouldBeReturn() {
			DeletePublisherCommand command = new DeletePublisherCommand(context);
			command.PublisherID = 1;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Publisher exists in a game.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Publisher_ShouldBeDeleted() {
			DeletePublisherCommand command = new DeletePublisherCommand(context);
			Publisher publisher = new Publisher() { Name = "CD PROJEKT RED", Year = 1994 };
			context.Publishers.Add(publisher);
			context.SaveChanges();
			command.PublisherID = publisher.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Publisher? result_publisher = context.Publishers.SingleOrDefault(p => p.ID == command.PublisherID);
			result_publisher.Should().BeNull();
		}
	}
}