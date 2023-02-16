using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using movie_store.Application.DirectorOperations.Commands.CreateDirector;
using movie_store.Application.DirectorOperations.Queries.GetDirectors;
using movie_store.Application.DirectorOperations.Queries.GetDirector;
using static movie_store.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static movie_store.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
using static movie_store.Application.DirectorOperations.Queries.GetDirector.GetDirectorQuery;
using movie_store.Application.DirectorOperations.Commands.UpdateDirector;
using movie_store.Application.DirectorOperations.Commands.DeleteDirector;
using movie_store.DBOperations;
namespace Director_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class DirectorController : ControllerBase {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public DirectorController(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetDirectors() {
			GetDirectorsQuery query = new GetDirectorsQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetDirector(int id) {
			GetDirectorViewModel result;
			GetDirectorQuery query = new GetDirectorQuery(context, mapper);
			query.DirectorID = id;
			GetDirectorQueryValidator validator = new GetDirectorQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateDirector([FromBody] CreateDirectorModel create_director_model) {
			CreateDirectorCommand command = new CreateDirectorCommand(context, mapper);
			command.Model = create_director_model;
			CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel update_director_model) {
			UpdateDirectorCommand command = new UpdateDirectorCommand(context);
			command.DirectorID = id;
			command.Model = update_director_model;
			UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteDirector(int id) {
			DeleteDirectorCommand command = new DeleteDirectorCommand(context);
			command.DirectorID = id;
			DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}