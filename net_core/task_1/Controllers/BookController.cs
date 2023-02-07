using Microsoft.AspNetCore.Mvc;
using task_1.BookOperations.CreateBook;
using task_1.BookOperations.GetBookByID;
using task_1.BookOperations.GetBooks;
using task_1.BookOperations.UpdateBook;
using task_1.DBOperations;
using static task_1.BookOperations.CreateBook.CreateBookCommand;
namespace task_1.Controllers {
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
			GetBookByIDQuery query = new GetBookByIDQuery(_context);
			var result = query.Handle(id);
			if (result == null) return NotFound();
			else return Ok(result);
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
			UpdateBookCommand command = new UpdateBookCommand(_context);
			try {
				command.Model = updateBook;
				command.Handle(id);
			} catch (Exception ex) {
				return NotFound(ex.Message);
			}
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id) {
			var book = _context.Books.SingleOrDefault(x => x.Id == id);
			if (book is null) return BadRequest();
			_context.Books.Remove(book);
			_context.SaveChanges();
			return Ok();
		}
	}
}