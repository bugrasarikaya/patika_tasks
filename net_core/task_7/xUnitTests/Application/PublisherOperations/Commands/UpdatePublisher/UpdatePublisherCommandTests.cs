using FluentAssertions;
using game_store.Application.PublisherOperations.Commands.UpdatePublisher;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.PublisherOperations.Commands.UpdatePublisher.UpdatePublisherCommand;
namespace xUnitTests.Application.PublisherOperations.Commands.UpadtePublisher {
	public class UpdatePublisherCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public UpdatePublisherCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistPublisherIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdatePublisherCommand command = new UpdatePublisherCommand(context);
			command.PublisherID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Publisher could not be found.");
		}
		[Fact]
		public void WhenAlreadyExistPublisherInfoIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdatePublisherCommand command = new UpdatePublisherCommand(context);
			Publisher publisher = new Publisher() { Name = "CD PROJEKT RED", Year = 1994 };
			context.Publishers.Add(publisher);
			context.SaveChanges();
			command.PublisherID = 1;
			command.Model = new UpdatePublisherModel() { Name = publisher.Name, Year = publisher.Year };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Publisher already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Publisher_ShouldBeUpdated() {
			UpdatePublisherCommand command = new UpdatePublisherCommand(context);
			UpdatePublisherModel model = new UpdatePublisherModel() { Name = "CD PROJEKT RED", Year = 1994 };
			command.Model = model;
			command.PublisherID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Publisher? publisher = context.Publishers.SingleOrDefault(p => p.ID == command.PublisherID);
			publisher.Should().NotBeNull();
		}
	}
}