using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using game_store.Application.DeveloperOperations.Commands.CreateDeveloper;
using game_store.Application.DeveloperOperations.Queries.GetDevelopers;
using game_store.Application.DeveloperOperations.Queries.GetDeveloper;
using game_store.Application.DeveloperOperations.Commands.UpdateDeveloper;
using game_store.Application.DeveloperOperations.Commands.DeleteDeveloper;
using game_store.DBOperations;
using static game_store.Application.DeveloperOperations.Commands.CreateDeveloper.CreateDeveloperCommand;
using static game_store.Application.DeveloperOperations.Commands.UpdateDeveloper.UpdateDeveloperCommand;
using static game_store.Application.DeveloperOperations.Queries.GetDeveloper.GetDeveloperQuery;
namespace Developer_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class DeveloperController : ControllerBase {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public DeveloperController(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetDevelopers() {
			GetDevelopersQuery query = new GetDevelopersQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetDeveloper(int id) {
			GetDeveloperViewModel result;
			GetDeveloperQuery query = new GetDeveloperQuery(context, mapper);
			query.DeveloperID = id;
			GetDeveloperQueryValidator validator = new GetDeveloperQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateDeveloper([FromBody] CreateDeveloperModel create_developer_model) {
			CreateDeveloperCommand command = new CreateDeveloperCommand(context, mapper);
			command.Model = create_developer_model;
			CreateDeveloperCommandValidator validator = new CreateDeveloperCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateDeveloper(int id, [FromBody] UpdateDeveloperModel update_developer_model) {
			UpdateDeveloperCommand command = new UpdateDeveloperCommand(context);
			command.DeveloperID = id;
			command.Model = update_developer_model;
			UpdateDeveloperCommandValidator validator = new UpdateDeveloperCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteDeveloper(int id) {
			DeleteDeveloperCommand command = new DeleteDeveloperCommand(context);
			command.DeveloperID = id;
			DeleteDeveloperCommandValidator validator = new DeleteDeveloperCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}