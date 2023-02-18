using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.UpdateGenre;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
namespace xUnitTests.Application.GenreOperations.Commands.UpdateGenre {
	public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public UpdateGenreCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistGenreIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateGenreCommand command = new UpdateGenreCommand(context);
			command.GenreID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre could not be found.");
		}
		[Fact]
		public void WhenExistGenreIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			Genre genre = new Genre() { Name = "Sci-Fi" };
			context.Genres.Add(genre);
			context.SaveChanges();
			UpdateGenreCommand command = new UpdateGenreCommand(context);
			command.GenreID = 1;
			command.Model = new UpdateGenreModel() { Name = genre.Name };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeUpdated() {
			UpdateGenreCommand command = new UpdateGenreCommand(context);
			UpdateGenreModel model = new UpdateGenreModel() { Name = "Sci-Fi" };
			command.Model = model;
			command.GenreID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Genre? genre = context.Genres.SingleOrDefault(g => g.ID == command.GenreID);
			genre.Should().NotBeNull();
		}
	}
}