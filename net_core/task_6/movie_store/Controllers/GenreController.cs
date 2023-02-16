using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using movie_store.Application.GenreOperations.Commands.CreateGenre;
using movie_store.Application.GenreOperations.Queries.GetGenres;
using movie_store.Application.GenreOperations.Queries.GetGenre;
using movie_store.Application.GenreOperations.Commands.UpdateGenre;
using movie_store.Application.GenreOperations.Commands.DeleteGenre;
using movie_store.DBOperations;
using static movie_store.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static movie_store.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using static movie_store.Application.GenreOperations.Queries.GetGenre.GetGenreQuery;
namespace Genre_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class GenreController : ControllerBase {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GenreController(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetGenres() {
			GetGenresQuery query = new GetGenresQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetGenre(int id) {
			GetGenreViewModel result;
			GetGenreQuery query = new GetGenreQuery(context, mapper);
			query.GenreID = id;
			GetGenreQueryValidator validator = new GetGenreQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateGenre([FromBody] CreateGenreModel create_genre_model) {
			CreateGenreCommand command = new CreateGenreCommand(context, mapper);
			command.Model = create_genre_model;
			CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel update_genre_model) {
			UpdateGenreCommand command = new UpdateGenreCommand(context);
			command.GenreID = id;
			command.Model = update_genre_model;
			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteGenre(int id) {
			DeleteGenreCommand command = new DeleteGenreCommand(context);
			command.GenreID = id;
			DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}