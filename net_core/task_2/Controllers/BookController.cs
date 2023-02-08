using Microsoft.AspNetCore.Mvc;
using task_2.BookOperations.CreateBook;
using task_2.BookOperations.DeleteBook;
using task_2.BookOperations.GetBookDetail;
using task_2.BookOperations.GetBooks;
using task_2.BookOperations.UpdateBook;
using task_2.DBOperations;
using static task_2.BookOperations.CreateBook.CreateBookCommand;
namespace task_2.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class BookController : ControllerBase {
		private readonly BookStoreDbContext _context;
		public BookController(BookStoreDbContext context) {
			_context = context;
		}
		[HttpGet]
		public IActionResult GetBooks() {
			GetBooksQuery query = new GetBooksQuery(_context);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetByID(int id) {
			BookDetailViewModel result;
			try {
				GetBookDetailQuery query = new GetBookDetailQuery(_context);
				query.BookID = id;
				result = query.Handle(id);
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			return Ok(result);
		}
		[HttpPost]
		public IActionResult AddBook([FromBody] CreateBookModel newBook) {
			CreateBookCommand command = new CreateBookCommand(_context);
			try {
				command.Model = newBook;
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
				command.Handle();
			} catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			return Ok();
		}
	}
}