using AutoMapper;
using FluentAssertions;
using task_4.Application.GenreOperations.Commands.CreateGenre;
using task_4.DBOperations;
using task_4.Entities;
using task_5.TestSetup;
using static task_4.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
namespace task_5.Application.GenreOperations.Commands.CreateGenre {
	public class CreateGenreCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		public CreateGenreCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.Context;
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