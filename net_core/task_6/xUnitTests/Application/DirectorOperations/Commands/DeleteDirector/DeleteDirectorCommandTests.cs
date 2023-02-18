using FluentAssertions;
using movie_store.Application.DirectorOperations.Commands.DeleteDirector;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DirectorOperations.Commands.DeleteDirector {
	public class DeleteDirectorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public DeleteDirectorCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistDirectorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteDirectorCommand command = new DeleteDirectorCommand(context);
			command.DirectorID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director could not be found.");
		}
		[Fact]
		public void WhenGivenDirectorIDExistsInMovies_InvalidOperationException_ShouldBeReturn() {
			DeleteDirectorCommand command = new DeleteDirectorCommand(context);
			command.DirectorID = 1;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director exists in a movie.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Director_ShouldBeDeleted() {
			DeleteDirectorCommand command = new DeleteDirectorCommand(context);
			Director director = new Director() { Name = "Lana", Surname = "Wachowski" };
			context.Directors.Add(director);
			context.SaveChanges();
			command.DirectorID = director.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Director? result_director = context.Directors.SingleOrDefault(d => d.ID == command.DirectorID);
			result_director.Should().BeNull();
		}
	}
}