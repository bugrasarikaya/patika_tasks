using AutoMapper;
using FluentAssertions;
using movie_store.Application.AuthorOperations.Queries.GetAuthorDetail;
using movie_store.DBOperations;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.AuthorOperations.Queries.GetAuthorDetail {
	public class GetAuthorDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public GetAuthorDetailQueryTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;
		}
		[Fact]
		public void WhenNotExistAuthortIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
			query.AuthorID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı!");
		}
		[Fact]
		public void WhenValidInputAreGiven_Author_ShouldBeReturn() {
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
			query.AuthorID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			var Author = _context.Authors.SingleOrDefault(Author => Author.ID == query.AuthorID);
			Author.Should().NotBeNull();
		}
	}
}