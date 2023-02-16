using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using movie_store.Application.ActorOperations.Commands.CreateActor;
using movie_store.Application.ActorOperations.Queries.GetActors;
using movie_store.Application.ActorOperations.Queries.GetActor;
using movie_store.Application.ActorOperations.Commands.UpdateActor;
using movie_store.Application.ActorOperations.Commands.DeleteActor;
using movie_store.DBOperations;
using static movie_store.Application.ActorOperations.Commands.CreateActor.CreateActorCommand;
using static movie_store.Application.ActorOperations.Commands.UpdateActor.UpdateActorCommand;
using static movie_store.Application.ActorOperations.Queries.GetActor.GetActorQuery;
namespace Actor_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class ActorController : ControllerBase {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public ActorController(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetActors() {
			GetActorsQuery query = new GetActorsQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetActor(int id) {
			GetActorViewModel result;
			GetActorQuery query = new GetActorQuery(context, mapper);
			query.ActorID = id;
			GetActorQueryValidator validator = new GetActorQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateActor([FromBody] CreateActorModel create_actor_model) {
			CreateActorCommand command = new CreateActorCommand(context, mapper);
			command.Model = create_actor_model;
			CreateActorCommandValidator validator = new CreateActorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel update_actor_model) {
			UpdateActorCommand command = new UpdateActorCommand(context);
			command.ActorID = id;
			command.Model = update_actor_model;
			UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteActor(int id) {
			DeleteActorCommand command = new DeleteActorCommand(context);
			command.ActorID = id;
			DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}