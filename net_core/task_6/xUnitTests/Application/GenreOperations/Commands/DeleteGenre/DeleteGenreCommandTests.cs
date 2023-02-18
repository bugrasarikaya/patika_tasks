using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.DeleteGenre;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Commands.DeleteGenre {
	public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public DeleteGenreCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistGenreIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteGenreCommand command = new DeleteGenreCommand(context);
			command.GenreID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre could not be found.");
		}
		[Fact]
		public void WhenGivenGenreIDExistsInMovies_InvalidOperationException_ShouldBeReturn() {
			DeleteGenreCommand command = new DeleteGenreCommand(context);
			command.GenreID = 1;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre exists in a movie.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeDeleted() {
			DeleteGenreCommand command = new DeleteGenreCommand(context);
			Genre genre = new Genre() { Name = "Sci-Fi" };
			context.Genres.Add(genre);
			context.SaveChanges();
			command.GenreID = genre.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Genre? result_genre = context.Genres.SingleOrDefault(g => g.ID == command.GenreID);
			result_genre.Should().BeNull();
		}
	}
}