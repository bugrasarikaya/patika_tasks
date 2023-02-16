using AutoMapper;
using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.CreateGenre;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
namespace xUnitTests.Application.GenreOperations.Commands.CreateGenre {
	public class CreateGenreCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public CreateGenreCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.context;
		}
		[Fact]
		public void WhenAlreadyExistGenretTitleIsGiven_InvalidOperationException_ShouldBeReturn() {
			var Genre = new Genre() { Name = "Test_WhenAlreadyExistGenretTitleIsGiven_InvalidOperationException_ShouldBeReturn", IsActive = true };
			_context.Genres.Add(Genre);
			_context.SaveChanges();
			CreateGenreCommand command = new CreateGenreCommand(_context);
			command.Model = new CreateGenreModel() { Name = Genre.Name };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Zaten Mevcut.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeCreated() {
			CreateGenreCommand command = new CreateGenreCommand(_context);
			CreateGenreModel model = new CreateGenreModel() { Name = "Test_WhenValidInputAreGiven_Genre_ShouldBeCreated"};
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var Genre = _context.Genres.SingleOrDefault(Genre => Genre.Name == model.Name);
			Genre.Should().NotBeNull();
			Genre.Name.Should().Be(model.Name);
		}
	}
}