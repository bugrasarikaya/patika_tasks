using FluentAssertions;
using movie_store.Application.ActorOperations.Commands.UpdateActor;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.ActorOperations.Commands.UpdateActor.UpdateActorCommand;
namespace xUnitTests.Application.ActorOperations.Commands.UpadteActor {
	public class UpdateActorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public UpdateActorCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistActorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateActorCommand command = new UpdateActorCommand(context);
			command.ActorID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor could not be found.");
		}
		[Fact]
		public void WhenAlreadyExistActorInfoIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateActorCommand command = new UpdateActorCommand(context);
			Actor actor = new Actor() { Name = "Keanu", Surname = "Reeves" };
			context.Actors.Add(actor);
			context.SaveChanges();
			command.ActorID = 1;
			command.Model = new UpdateActorModel() { Name = actor.Name, Surname = actor.Surname };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Actor_ShouldBeUpdated() {
			UpdateActorCommand command = new UpdateActorCommand(context);
			UpdateActorModel model = new UpdateActorModel() { Name = "Keanu", Surname = "Reeves" };
			command.Model = model;
			command.ActorID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Actor? actor = context.Actors.SingleOrDefault(a => a.ID == command.ActorID);
			actor.Should().NotBeNull();
		}
	}
}