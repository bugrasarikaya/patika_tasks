using AutoMapper;
using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.UpdateGenre;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Commands.UpadteGenre {
	public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public UpdateGenreCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
		}
		[Fact]
		public void WhenNotExistGenretIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateGenreCommand command = new UpdateGenreCommand(_context);
			command.GenreID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü bulunamadı!");
		}
		[Fact]
		public void WhenExistGenretNameIsGiven_InvalidOperationException_ShouldBeReturn() {
			var genre = new Genre() { Name = "Test_WhenExistGenretNameIsGiven_InvalidOperationException_ShouldBeReturn", IsActive = true };
			_context.Genres.Add(genre);
			_context.SaveChanges();
			UpdateGenreCommand command = new UpdateGenreCommand(_context);
			command.GenreID = 1;
			command.Model = new UpdateGenreModel() { Name = genre.Name, IsActive = true };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimli bir kitap türü zaten mevcut");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeUpdated() {
			UpdateGenreCommand command = new UpdateGenreCommand(_context);
			UpdateGenreModel model = new UpdateGenreModel() { Name = "Thriller", IsActive = true };
			command.Model = model;
			command.GenreID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var Genre = _context.Genres.SingleOrDefault(Genre => Genre.ID == command.GenreID);
			Genre.Should().NotBeNull();
		}
	}
}