using AutoMapper;
using FluentAssertions;
using movie_store.Application.GenreOperations.Queries.GetGenre;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Queries.GetGenre {
	public class GetGenreQueryTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetGenreQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistGenreIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetGenreQuery query = new GetGenreQuery(context, mapper);
			query.GenreID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeReturn() {
			GetGenreQuery query = new GetGenreQuery(context, mapper);
			query.GenreID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Genre? genre = context.Genres.SingleOrDefault(g => g.ID == query.GenreID);
			genre.Should().NotBeNull();
		}
	}
}