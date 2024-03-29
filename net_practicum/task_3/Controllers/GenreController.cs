﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using task_4.Application.GenreOperations.Commands.CreateGenre;
using task_4.Application.GenreOperations.DeleteGenre;
using task_4.Application.GenreOperations.Queries.GetGenreDetail;
using task_4.Application.GenreOperations.Queries.GetGenres;
using task_4.Application.GenreOperations.UpdateGenre;
using task_4.DBOperations;

namespace task_4.Controllers {
	[ApiController]
	[Route("[Controller]s")]
	public class GenreController : ControllerBase {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public GenreController(BookStoreDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}
		[HttpGet]
		public ActionResult GetGenres() {
			GetGenresQuery query = new GetGenresQuery(_context, _mapper);
			var obj = query.Handle();
			return Ok(obj);
		}
		[HttpGet("id")]
		public ActionResult GetGenreDetail(int id) {
			GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
			query.GenreID = id;
			GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
			validator.ValidateAndThrow(query);
			var obj = query.Handle();
			return Ok(obj);
		}
		[HttpPost]
		public IActionResult AddGenre([FromBody] CreateGenreModel newGenre) {
			CreateGenreCommand command = new CreateGenreCommand(_context);
			command.Model = newGenre;
			CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("id")]
		public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre) {
			UpdateGenreCommand command = new UpdateGenreCommand(_context);
			command.GenreID = id;
			command.Model = updateGenre;
			UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("id")]
		public IActionResult DeleteGenre(int id) {
			DeleteGenreCommand command = new DeleteGenreCommand(_context);
			command.GenreID = id;
			DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}