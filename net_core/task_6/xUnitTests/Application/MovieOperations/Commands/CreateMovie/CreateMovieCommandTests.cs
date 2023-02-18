using AutoMapper;
using FluentAssertions;
using movie_store.Application.MovieOperations.Commands.CreateMovie;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
namespace xUnitTests.Application.MovieOperations.Commands.CreateMovie {
	public class CreateMovieCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateMovieCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistMovieNameGiven_InvalidOperationException_ShouldBeReturn() {
			Movie movie = new Movie() { Name = "Matrix", Year = 1999, Price = 17.99 };
			context.Movies.Add(movie);
			context.SaveChanges();
			CreateMovieCommand command = new CreateMovieCommand(context, mapper);
			command.Model = new CreateMovieModel() { Name = movie.Name , Year = movie.Year, Price = movie.Price};
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Movie_ShouldBeCreated() {
			CreateMovieCommand command = new CreateMovieCommand(context, mapper);
			CreateMovieModel model = new CreateMovieModel() { Name = "Matrix", Year = 1999, Price = 17.99 };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Movie? movie = context.Movies.SingleOrDefault(m => m.Name == model.Name);
			movie.Should().NotBeNull();
			movie?.Year.Should().Be(model.Year);
			movie?.Price.Should().Be(model.Price);
		}
	}
}