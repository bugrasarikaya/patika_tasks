using AutoMapper;
using FluentAssertions;
using game_store.Application.DeveloperOperations.Commands.CreateDeveloper;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.DeveloperOperations.Commands.CreateDeveloper.CreateDeveloperCommand;
namespace xUnitTests.Application.DeveloperOperations.Commands.CreateDeveloper {
	public class CreateDeveloperCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public CreateDeveloperCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistDeveloperIsGiven_InvalidOperationException_ShouldBeReturn() {
			Developer developer = new Developer() { Name = "CD PROJEKT RED", Year = 1994 };
			context.Developers.Add(developer);
			context.SaveChanges();
			CreateDeveloperCommand command = new CreateDeveloperCommand(context, mapper);
			command.Model = new CreateDeveloperModel() { Name = developer.Name, Year = developer.Year };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Developer already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Developer_ShouldBeCreated() {
			CreateDeveloperCommand command = new CreateDeveloperCommand(context, mapper);
			CreateDeveloperModel model = new CreateDeveloperModel() { Name = "CD PROJEKT RED", Year = 1994 };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Developer? developer = context.Developers.FirstOrDefault(d => d.Name == model.Name && d.Year == model.Year);
			developer.Should().NotBeNull();
			developer?.Name.Should().Be(model.Name);
			developer?.Year.Should().Be(model.Year);
		}
	}
}