using FluentAssertions;
using movie_store.Application.MovieOperations.Commands.UpdateMovie;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
namespace xUnitTests.Application.MovieOperations.Commands.UpadteMovie {
	public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public UpdateMovieCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistMovieIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateMovieCommand command = new UpdateMovieCommand(context);
			command.MovieID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie could not be found.");
		}
		[Fact]
		public void WhenNotExistActorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateMovieCommand command = new UpdateMovieCommand(context);
			command.MovieID = 1;
			command.Model = new UpdateMovieModel() { Name = "Matrix", Year = 1999, Price = 17.99, ActorIDs = new List<int>() { 0 }, DirectorIDs = new List<int>() { 1 }, GenreIDs = new List<int>() { 1 } };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor could not be found.");
		}
		[Fact]
		public void WhenNotExistDirectorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateMovieCommand command = new UpdateMovieCommand(context);
			command.MovieID = 1;
			command.Model = new UpdateMovieModel() { Name = "Matrix", Year = 1999, Price = 17.99, ActorIDs = new List<int>() { 1 }, DirectorIDs = new List<int>() { 0 }, GenreIDs = new List<int>() { 1 } };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director could not be found.");
		}
		[Fact]
		public void WhenNotExistGenreIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateMovieCommand command = new UpdateMovieCommand(context);
			command.MovieID = 1;
			command.Model = new UpdateMovieModel() { Name = "Matrix", Year = 1999, Price = 17.99, ActorIDs = new List<int>() { 1 }, DirectorIDs = new List<int>() { 1 }, GenreIDs = new List<int>() { 0 } };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Movie_ShouldBeUpdated() {
			UpdateMovieCommand command = new UpdateMovieCommand(context);
			UpdateMovieModel model = new UpdateMovieModel() { Name = "Matrix", Year = 1999, Price = 17.99, ActorIDs = new List<int>() { 1 }, DirectorIDs = new List<int>() { 1 }, GenreIDs = new List<int>() { 1 } };
			command.Model = model;
			command.MovieID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Movie? movie = context.Movies.SingleOrDefault(m => m.ID == command.MovieID);
			movie.Should().NotBeNull();
			List<MovieActor>? list_movie_actor = context.MovieActors.Where(ma => ma.MovieID == command.MovieID).ToList();
			list_movie_actor.Should().NotBeNull();
			list_movie_actor.Count.Should().Be(command.Model.ActorIDs.Count);
			for (int i = 0; i < list_movie_actor.Count; i++) list_movie_actor[0].ActorID.Should().Be(command.Model.ActorIDs[i]);
			List<MovieDirector>? list_movie_director = context.MovieDirectors.Where(ma => ma.MovieID == command.MovieID).ToList();
			list_movie_director.Should().NotBeNull();
			list_movie_director.Count.Should().Be(command.Model.DirectorIDs.Count);
			for (int i = 0; i < list_movie_director.Count; i++) list_movie_director[0].DirectorID.Should().Be(command.Model.DirectorIDs[i]);
			List<MovieGenre>? list_movie_genre = context.MovieGenres.Where(mg => mg.MovieID == command.MovieID).ToList();
			list_movie_genre.Should().NotBeNull();
			list_movie_genre.Count.Should().Be(command.Model.GenreIDs.Count);
			for (int i = 0; i < list_movie_genre.Count; i++) list_movie_genre[0].GenreID.Should().Be(command.Model.GenreIDs[i]);
		}
	}
}