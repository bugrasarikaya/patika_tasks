using FluentAssertions;
using movie_store.Application.AuthorOperations.Commands.DeleteAuthor;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.AuthorOperations.Commands.DeleteAuthor {
	public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public DeleteAuthorCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
		}
		[Fact]
		public void WhenNotExistAuthortIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yazar bulunamadı!");
		}
		[Fact]
		public void WhenExistBookIDIsGivenAuthorID_InvalidOperationException_ShouldBeReturn() {
			DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
			command.AuthorID = 1;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Mevcut yazarın bir kitabı var.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Author_ShouldBeDeleted() {
			DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
			var author = new Author() { Name = "TestName_WhenValidInputAreGiven_Author_ShouldBeDeleted", Surname = "TestName_WhenValidInputAreGiven_Author_ShouldBeDeleted", DateofBirth = DateTime.Now.Date.AddYears(-10) };
			_context.Authors.Add(author);
			_context.SaveChanges();
			command.AuthorID = author.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var Author = _context.Authors.SingleOrDefault(Author => Author.ID == command.AuthorID);
			Author.Should().BeNull();
		}
	}
}