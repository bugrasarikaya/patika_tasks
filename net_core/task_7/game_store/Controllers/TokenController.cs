using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using game_store.TokenOperations.Commands.CreateToken;
using game_store.DBOperations;
using game_store.TokenOperations.Models;
using static game_store.TokenOperations.Commands.CreateToken.CreateTokenCommand;
using game_store.TokenOperations.Commands.RefreshToken;
namespace Token_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class TokenController : ControllerBase {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		private readonly IConfiguration configuraiton;
		public TokenController(IGameStoreDbContext context, IMapper mapper, IConfiguration configuraiton) {
			this.context = context;
			this.mapper = mapper;
			this.configuraiton = configuraiton;
		}
		[HttpPost]
		public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login) {
			CreateTokenCommand command = new CreateTokenCommand(context, configuraiton);
			command.Model = login;
			CreateTokenCommandValidator validator = new CreateTokenCommandValidator();
			validator.ValidateAndThrow(command);
			var token = command.Handle();
			return Ok(token);
		}
		[HttpGet]
		public ActionResult<Token> RefreshToken([FromQuery] string token) {
			RefreshTokenCommand command = new RefreshTokenCommand(context, configuraiton);
			command.refresh_token = token;
			var result_token = command.Handle();
			return Ok(result_token);
		}
	}
}