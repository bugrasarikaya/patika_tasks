using FluentAssertions;
using movie_store.Application.MovieOperations.Commands.DeleteMovie;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.MovieOperations.Commands.DeleteMovie {
	public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public DeleteMovieCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistMovieIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteMovieCommand command = new DeleteMovieCommand(context);
			command.MovieID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Movie_ShouldBeDeleted() {
			DeleteMovieCommand command = new DeleteMovieCommand(context);
			Movie Movie = new Movie() { Name = "Matrix", Year = 1999, Price = 17.99 };
			context.Movies.Add(Movie);
			context.SaveChanges();
			command.MovieID = Movie.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Movie? result_movie = context.Movies.SingleOrDefault(m => m.ID == command.MovieID);
			result_movie.Should().BeNull();
		}
	}
}