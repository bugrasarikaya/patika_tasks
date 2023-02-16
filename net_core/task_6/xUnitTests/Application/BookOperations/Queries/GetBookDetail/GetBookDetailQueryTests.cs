using AutoMapper;
using FluentAssertions;
using movie_store.Application.BookOperations.Queries.GetBookDetail;
using movie_store.DBOperations;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.BookOperations.Queries.GetBookDetail {
	public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public GetBookDetailQueryTests(CommonTestFixture testFixture) {
			_context = testFixture.context;
			_mapper = testFixture.Mapper;
		}
		[Fact]
		public void WhenNotExistBooktIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
			query.BookID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı!");
		}
		[Fact]
		public void WhenValidInputAreGiven_Book_ShouldBeReturn() {
			GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
			query.BookID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			var book = _context.Books.SingleOrDefault(book => book.ID == query.BookID);
			book.Should().NotBeNull();
		}
	}
}