using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using movie_store.Application.MovieOperations.Commands.CreateMovie;
using movie_store.Application.MovieOperations.Queries.GetMovies;
using movie_store.Application.MovieOperations.Queries.GetMovie;
using movie_store.DBOperations;
using movie_store.Application.MovieOperations.Commands.UpdateMovie;
using movie_store.Application.MovieOperations.Commands.DeleteMovie;
using static movie_store.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static movie_store.Application.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
using static movie_store.Application.MovieOperations.Queries.GetMovie.GetMovieQuery;
namespace movie_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class MovieController : ControllerBase {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public MovieController(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetMovies() {
			GetMoviesQuery query = new GetMoviesQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetMovie(int id) {
			GetMovieViewModel result;
			GetMovieQuery query = new GetMovieQuery(context, mapper);
			query.MovieID = id;
			GetMovieQueryValidator validator = new GetMovieQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateMovie([FromBody] CreateMovieModel create_movie_model) {
			CreateMovieCommand command = new CreateMovieCommand(context, mapper);
			command.Model = create_movie_model;
			CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel update_movie_model) {
			UpdateMovieCommand command = new UpdateMovieCommand(context);
			command.MovieID = id;
			command.Model = update_movie_model;
			UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMovie(int id) {
			DeleteMovieCommand command = new DeleteMovieCommand(context);
			command.MovieID = id;
			DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}