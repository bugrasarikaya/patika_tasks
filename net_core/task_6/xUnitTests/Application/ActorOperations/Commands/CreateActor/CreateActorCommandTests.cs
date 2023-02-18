using AutoMapper;
using FluentAssertions;
using movie_store.Application.ActorOperations.Commands.CreateActor;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.ActorOperations.Commands.CreateActor.CreateActorCommand;
namespace xUnitTests.Application.ActorOperations.Commands.CreateActor {
	public class CreateActorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateActorCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistActorIsGiven_InvalidOperationException_ShouldBeReturn() {
			Actor actor = new Actor() { Name = "Keanu", Surname = "Reeves" };
			context.Actors.Add(actor);
			context.SaveChanges();
			CreateActorCommand command = new CreateActorCommand(context, mapper);
			command.Model = new CreateActorModel() { Name = actor.Name, Surname = actor.Surname };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Actor_ShouldBeCreated() {
			CreateActorCommand command = new CreateActorCommand(context, mapper);
			CreateActorModel model = new CreateActorModel() { Name = "Keanu", Surname = "Reeves" };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Actor? actor = context.Actors.FirstOrDefault(a => a.Name == model.Name && a.Surname == model.Surname);
			actor.Should().NotBeNull();
			actor?.Name.Should().Be(model.Name);
			actor?.Surname.Should().Be(model.Surname);
		}
	}
}