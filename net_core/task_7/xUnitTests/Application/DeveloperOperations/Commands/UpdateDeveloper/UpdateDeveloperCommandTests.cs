using FluentAssertions;
using game_store.Application.DeveloperOperations.Commands.UpdateDeveloper;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.DeveloperOperations.Commands.UpdateDeveloper.UpdateDeveloperCommand;
namespace xUnitTests.Application.DeveloperOperations.Commands.UpadteDeveloper {
	public class UpdateDeveloperCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public UpdateDeveloperCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistDeveloperIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateDeveloperCommand command = new UpdateDeveloperCommand(context);
			command.DeveloperID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Developer could not be found.");
		}
		[Fact]
		public void WhenAlreadyExistDeveloperInfoIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateDeveloperCommand command = new UpdateDeveloperCommand(context);
			Developer developer = new Developer() { Name = "CD PROJEKT RED", Year = 1994 };
			context.Developers.Add(developer);
			context.SaveChanges();
			command.DeveloperID = 1;
			command.Model = new UpdateDeveloperModel() { Name = developer.Name, Year = developer.Year };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Developer already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Developer_ShouldBeUpdated() {
			UpdateDeveloperCommand command = new UpdateDeveloperCommand(context);
			UpdateDeveloperModel model = new UpdateDeveloperModel() { Name = "CD PROJEKT RED", Year = 1994 };
			command.Model = model;
			command.DeveloperID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Developer? developer = context.Developers.SingleOrDefault(d => d.ID == command.DeveloperID);
			developer.Should().NotBeNull();
		}
	}
}