﻿using AutoMapper;
using FluentAssertions;
using task_4.Application.BookOperations.Commands.UpdateBook;
using task_4.DBOperations;
using task_4.Entities;
using task_5.TestSetup;
namespace task_5.Application.BookOperations.Commands.UpadteBook {
	public class UpdateBookCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public UpdateBookCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
		}
		[Fact]
		public void WhenNotExistBooktIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateBookCommand command = new UpdateBookCommand(_context);
			command.BookID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellencek Kitap Bulunamadı!");
		}
		[Fact]
		public void WhenValidInputAreGiven_Book_ShouldBeUpdated() {
			UpdateBookCommand command = new UpdateBookCommand(_context);
			UpdateBookModel model = new UpdateBookModel() { Title = "Hobbit", AuthorID = 2, GenreID = 1 };
			command.Model = model;
			command.BookID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var book = _context.Books.SingleOrDefault(book => book.ID == command.BookID);
			book.Should().NotBeNull();
		}
	}
}