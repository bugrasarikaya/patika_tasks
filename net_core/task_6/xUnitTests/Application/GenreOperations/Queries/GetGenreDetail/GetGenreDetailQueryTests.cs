using AutoMapper;
using FluentAssertions;
using movie_store.Application.GenreOperations.Queries.GetGenreDetail;
using movie_store.DBOperations;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Queries.GetGenreDetail {
	public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public GetGenreDetailQueryTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;
		}
		[Fact]
		public void WhenNotExistGenretIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
			query.GenreID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı!");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeReturn() {
			GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
			query.GenreID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			var Genre = _context.Genres.SingleOrDefault(Genre => Genre.ID == query.GenreID);
			Genre.Should().NotBeNull();
		}
	}
}