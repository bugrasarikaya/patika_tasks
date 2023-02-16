﻿using AutoMapper;
using FluentAssertions;
using movie_store.Application.AuthorOperations.Commands.UpdateAuthor;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.AuthorOperations.Commands.UpadteAuthor {
	public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public UpdateAuthorCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.context;
		}
		[Fact]
		public void WhenNotExistAuthortIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
			command.AuthorID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellencek Yazar Bulunamadı!");
		}
		[Fact]
		public void WhenValidInputAreGiven_Author_ShouldBeUpdated() {
			UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
			UpdateAuthorModel model = new UpdateAuthorModel() { Name = "Andrzej", Surname = "Sapkowski", DateofBirth = new DateTime(1946, 06, 21) };
			command.Model = model;
			command.AuthorID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var author = _context.Authors.SingleOrDefault(Author => Author.ID == command.AuthorID);
			author.Should().NotBeNull();
		}
	}
}