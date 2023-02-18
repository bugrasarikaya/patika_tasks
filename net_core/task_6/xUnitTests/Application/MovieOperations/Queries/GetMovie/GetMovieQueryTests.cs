using AutoMapper;
using FluentAssertions;
using movie_store.Application.MovieOperations.Queries.GetMovie;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.MovieOperations.Queries.GetMovie {
	public class GetMovieQueryTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetMovieQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistMovieIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetMovieQuery query = new GetMovieQuery(context, mapper);
			query.MovieID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Movie_ShouldBeReturn() {
			GetMovieQuery query = new GetMovieQuery(context, mapper);
			query.MovieID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Movie? movie = context.Movies.SingleOrDefault(m => m.ID == query.MovieID);
			movie.Should().NotBeNull();
		}
	}
}