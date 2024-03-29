﻿using FluentAssertions;
using task_4.Application.BookOperations.Commands.DeleteBook;
using task_4.DBOperations;
using task_5.TestSetup;
namespace task_5.Application.BookOperations.Commands.DeleteBook {
	public class DeleteBookCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public DeleteBookCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
		}
		[Fact]
		public void WhenNotExistBooktIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteBookCommand command = new DeleteBookCommand(_context);
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadı!");
		}
		[Fact]
		public void WhenValidInputAreGiven_Book_ShouldBeDeleted() {
			DeleteBookCommand command = new DeleteBookCommand(_context);
			command.BookID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var book = _context.Books.SingleOrDefault(book => book.ID == command.BookID);
			book.Should().BeNull();
		}
	}
}