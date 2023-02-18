using FluentAssertions;
using movie_store.Application.ActorOperations.Commands.DeleteActor;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.ActorOperations.Commands.DeleteActor {
	public class DeleteActorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public DeleteActorCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistActorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteActorCommand command = new DeleteActorCommand(context);
			command.ActorID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor could not be found.");
		}
		[Fact]
		public void WhenGivenActorIDExistsInMovies_InvalidOperationException_ShouldBeReturn() {
			DeleteActorCommand command = new DeleteActorCommand(context);
			command.ActorID = 1;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor exists in a movie.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Actor_ShouldBeDeleted() {
			DeleteActorCommand command = new DeleteActorCommand(context);
			Actor actor = new Actor() { Name = "Kean", Surname = "Reeves" };
			context.Actors.Add(actor);
			context.SaveChanges();
			command.ActorID = actor.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Actor? result_actor = context.Actors.SingleOrDefault(a => a.ID == command.ActorID);
			result_actor.Should().BeNull();
		}
	}
}