using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.DeleteGenre;
using movie_store.DBOperations;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Commands.DeleteGenre {
	public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public DeleteGenreCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
		}
		[Fact]
		public void WhenNotExistGenretIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteGenreCommand command = new DeleteGenreCommand(_context);
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı!");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeDeleted() {
			DeleteGenreCommand command = new DeleteGenreCommand(_context);
			command.GenreID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var Genre = _context.Genres.SingleOrDefault(Genre => Genre.ID == command.GenreID);
			Genre.Should().BeNull();
		}
	}
}