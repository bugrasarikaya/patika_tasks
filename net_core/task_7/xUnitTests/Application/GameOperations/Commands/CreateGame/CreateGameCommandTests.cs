using AutoMapper;
using FluentAssertions;
using game_store.Application.GameOperations.Commands.CreateGame;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.GameOperations.Commands.CreateGame.CreateGameCommand;
namespace xUnitTests.Application.GameOperations.Commands.CreateGame {
	public class CreateGameCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public CreateGameCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistGameNameGiven_InvalidOperationException_ShouldBeReturn() {
			Game game = new Game() { Name = "The Witcher 3: Wild Hunt", Year = 2015, Price = 39.99 };
			context.Games.Add(game);
			context.SaveChanges();
			CreateGameCommand command = new CreateGameCommand(context, mapper);
			command.Model = new CreateGameModel() { Name = game.Name, Year = game.Year, Price = game.Price };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Game already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Game_ShouldBeCreated() {
			CreateGameCommand command = new CreateGameCommand(context, mapper);
			CreateGameModel model = new CreateGameModel() { Name = "The Witcher 3: Wild Hunt", Year = 2015, Price = 39.99 };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Game? game = context.Games.SingleOrDefault(g => g.Name == model.Name);
			game.Should().NotBeNull();
			game?.Year.Should().Be(model.Year);
			game?.Price.Should().Be(model.Price);
		}
	}
}