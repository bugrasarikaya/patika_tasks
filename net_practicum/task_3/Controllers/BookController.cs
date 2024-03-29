﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using task_4.Application.BookOperations.Commands.CreateBook;
using task_4.Application.BookOperations.Commands.DeleteBook;
using task_4.Application.BookOperations.Commands.UpdateBook;
using task_4.Application.BookOperations.Queries.GetBookDetail;
using task_4.Application.BookOperations.Queries.GetBooks;
using task_4.DBOperations;
using static task_4.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
namespace task_4.Controllers
{
    [ApiController]
	[Route("[controller]s")]
	public class BookController : ControllerBase {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public BookController(BookStoreDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetBooks() {
			GetBooksQuery query = new GetBooksQuery(_context, _mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetByID(int id) {
			BookDetailViewModel result;
			GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
			query.BookID = id;
			GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult AddBook([FromBody] CreateBookModel newBook) {
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			command.Model = newBook;
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook) {
			UpdateBookCommand command = new UpdateBookCommand(_context);
			command.BookID = id;
			command.Model = updateBook;
			UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id) {
			DeleteBookCommand command = new DeleteBookCommand(_context);
			command.BookID = id;
			DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}