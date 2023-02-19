using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using game_store.Application.GameOperations.Commands.CreateGame;
using game_store.Application.GameOperations.Queries.GetGames;
using game_store.Application.GameOperations.Queries.GetGame;
using game_store.DBOperations;
using game_store.Application.GameOperations.Commands.UpdateGame;
using game_store.Application.GameOperations.Commands.DeleteGame;
using static game_store.Application.GameOperations.Commands.CreateGame.CreateGameCommand;
using static game_store.Application.GameOperations.Commands.UpdateGame.UpdateGameCommand;
using static game_store.Application.GameOperations.Queries.GetGame.GetGameQuery;
namespace game_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class GameController : ControllerBase {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public GameController(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetGames() {
			GetGamesQuery query = new GetGamesQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetGame(int id) {
			GetGameViewModel result;
			GetGameQuery query = new GetGameQuery(context, mapper);
			query.GameID = id;
			GetGameQueryValidator validator = new GetGameQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateGame([FromBody] CreateGameModel create_game_model) {
			CreateGameCommand command = new CreateGameCommand(context, mapper);
			command.Model = create_game_model;
			CreateGameCommandValidator validator = new CreateGameCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateGame(int id, [FromBody] UpdateGameModel update_game_model) {
			UpdateGameCommand command = new UpdateGameCommand(context);
			command.GameID = id;
			command.Model = update_game_model;
			UpdateGameCommandValidator validator = new UpdateGameCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteGame(int id) {
			DeleteGameCommand command = new DeleteGameCommand(context);
			command.GameID = id;
			DeleteGameCommandValidator validator = new DeleteGameCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}