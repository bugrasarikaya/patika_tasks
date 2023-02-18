using AutoMapper;
using FluentAssertions;
using movie_store.Application.GenreOperations.Commands.CreateGenre;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
namespace xUnitTests.Application.GenreOperations.Commands.CreateGenre {
	public class CreateGenreCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateGenreCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistGenreIsGiven_InvalidOperationException_ShouldBeReturn() {
			Genre genre = new Genre() { Name = "Sci-Fi" };
			context.Genres.Add(genre);
			context.SaveChanges();
			CreateGenreCommand command = new CreateGenreCommand(context, mapper);
			command.Model = new CreateGenreModel() { Name = genre.Name };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Genre_ShouldBeCreated() {
			CreateGenreCommand command = new CreateGenreCommand(context, mapper);
			CreateGenreModel model = new CreateGenreModel() { Name = "Sci-Fi" };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Genre? genre = context.Genres.SingleOrDefault(g => g.Name == model.Name);
			genre?.Should().NotBeNull();
			genre?.Name.Should().Be(model.Name);
		}
	}
}