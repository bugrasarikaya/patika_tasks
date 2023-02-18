using AutoMapper;
using FluentAssertions;
using movie_store.Application.DirectorOperations.Commands.CreateDirector;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
namespace xUnitTests.Application.DirectorOperations.Commands.CreateDirector {
	public class CreateDirectorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateDirectorCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistDirectorIsGiven_InvalidOperationException_ShouldBeReturn() {
			Director director = new Director() { Name = "Lana", Surname = "Wachowski" };
			context.Directors.Add(director);
			context.SaveChanges();
			CreateDirectorCommand command = new CreateDirectorCommand(context, mapper);
			command.Model = new CreateDirectorModel() { Name = director.Name, Surname = director.Surname };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Director_ShouldBeCreated() {
			CreateDirectorCommand command = new CreateDirectorCommand(context, mapper);
			CreateDirectorModel model = new CreateDirectorModel() { Name = "Lana", Surname = "Wachowski" };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Director? director = context.Directors.FirstOrDefault(d => d.Name == model.Name && d.Surname == model.Surname);
			director.Should().NotBeNull();
			director?.Name.Should().Be(model.Name);
			director?.Surname.Should().Be(model.Surname);
		}
	}
}