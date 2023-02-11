using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using task_4.Application.AuthorOperations.Commands.CreateAuthor;
using task_4.Application.AuthorOperations.Commands.DeleteAuthor;
using task_4.Application.AuthorOperations.Commands.UpdateAuthor;
using task_4.Application.AuthorOperations.Queries.GetAuthorDetail;
using task_4.Application.AuthorOperations.Queries.GetAuthors;
using task_4.DBOperations;
using static task_4.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
namespace task_4.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class AuthorController : ControllerBase {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public AuthorController(BookStoreDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetAuthors() {
			GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetByID(int id) {
			AuthorDetailViewModel result;
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
			query.AuthorID = id;
			GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor) {
			CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
			command.Model = newAuthor;
			CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor) {
			UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
			command.AuthorID = id;
			command.Model = updateAuthor;
			UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteAuthor(int id) {
			DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
			command.AuthorID = id;
			DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}