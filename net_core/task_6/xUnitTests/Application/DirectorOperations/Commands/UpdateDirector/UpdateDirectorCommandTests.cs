using FluentAssertions;
using movie_store.Application.ActorOperations.Commands.UpdateActor;
using movie_store.Application.DirectorOperations.Commands.UpdateDirector;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.ActorOperations.Commands.UpdateActor.UpdateActorCommand;
using static movie_store.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
namespace xUnitTests.Application.DirectorOperations.Commands.UpadteDirector {
	public class UpdateDirectorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public UpdateDirectorCommandTests(CommonTestFixture testFixture) {
			context = testFixture.Context;
		}
		[Fact]
		public void WhenNotExistDirectorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateDirectorCommand command = new UpdateDirectorCommand(context);
			command.DirectorID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director could not be found.");
		}
		[Fact]
		public void WhenAlreadyExistDirectorInfoIsGiven_InvalidOperationException_ShouldBeReturn() {
			Director director = new Director() { Name = "Lana", Surname = "Wachowski" };
			context.Directors.Add(director);
			context.SaveChanges();
			UpdateDirectorCommand command = new UpdateDirectorCommand(context);
			command.DirectorID = 1;
			command.Model = new UpdateDirectorModel() { Name = director.Name, Surname = director.Surname };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Director_ShouldBeUpdated() {
			UpdateDirectorCommand command = new UpdateDirectorCommand(context);
			UpdateDirectorModel model = new UpdateDirectorModel() { Name = "Lana", Surname = "Wachowski" };
			command.Model = model;
			command.DirectorID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Director? director = context.Directors.SingleOrDefault(d => d.ID == command.DirectorID);
			director.Should().NotBeNull();
		}
	}
}