using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using task_3.BookOperations.CreateBook;
using task_3.BookOperations.DeleteBook;
using task_3.BookOperations.GetBookDetail;
using task_3.BookOperations.GetBooks;
using task_3.BookOperations.UpdateBook;
using task_3.DBOperations;
using static task_3.BookOperations.CreateBook.CreateBookCommand;
namespace task_3.Controllers {
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
			try {
				GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
				query.BookID = id;
				GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
				ValidationResult result_validation = validator.Validate(query);
				validator.ValidateAndThrow(query);
				result = query.Handle();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			return Ok(result);
		}
		[HttpPost]
		public IActionResult AddBook([FromBody] CreateBookModel newBook) {
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			try {
				command.Model = newBook;
				CreateBookCommandValidator validator = new CreateBookCommandValidator();
				ValidationResult result = validator.Validate(command);
				validator.ValidateAndThrow(command);
				command.Handle();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook) {
			try {
				UpdateBookCommand command = new UpdateBookCommand(_context);
				command.BookID = id;
				command.Model = updateBook;
				UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
				ValidationResult result = validator.Validate(command);
				validator.ValidateAndThrow(command);
				command.Handle();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id) {
			try {
				DeleteBookCommand command = new DeleteBookCommand(_context);
				command.BookID = id;
				DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
				validator.ValidateAndThrow(command);
				command.Handle();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			return Ok();
		}
	}
}