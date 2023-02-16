using AutoMapper;
using FluentAssertions;
using movie_store.Application.BookOperations.Commands.CreateBook;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
namespace xUnitTests.Application.BookOperations.Commands.CreateBook {
	public class CreateBookCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public CreateBookCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.context;
			_mapper = testFixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistBooktTitleIsGiven_InvalidOperationException_ShouldBeReturn() {
			var book = new Book() { Title = "Test_WhenAlreadyExistBooktTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1990, 01, 10), GenreID = 1, AuthorID = 1 };
			_context.Books.Add(book);
			_context.SaveChanges();
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			command.Model = new CreateBookModel() { Title = book.Title };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Book_ShouldBeCreated() {
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			CreateBookModel model = new CreateBookModel() { Title = "Test_WhenValidInputAreGiven_Book_ShouldBeCreated", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreID = 1, AuthorID = 1};
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
			book.Should().NotBeNull();
			book.PageCount.Should().Be(model.PageCount);
			book.PublishDate.Should().Be(model.PublishDate);
			book.GenreID.Should().Be(model.GenreID);
		}
	}
}