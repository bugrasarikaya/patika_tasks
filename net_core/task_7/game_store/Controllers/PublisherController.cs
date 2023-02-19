using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using game_store.Application.PublisherOperations.Commands.CreatePublisher;
using game_store.Application.PublisherOperations.Queries.GetPublishers;
using game_store.Application.PublisherOperations.Queries.GetPublisher;
using game_store.Application.PublisherOperations.Commands.UpdatePublisher;
using game_store.Application.PublisherOperations.Commands.DeletePublisher;
using game_store.DBOperations;
using static game_store.Application.PublisherOperations.Commands.CreatePublisher.CreatePublisherCommand;
using static game_store.Application.PublisherOperations.Commands.UpdatePublisher.UpdatePublisherCommand;
using static game_store.Application.PublisherOperations.Queries.GetPublisher.GetPublisherQuery;
namespace Publisher_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class PublisherController : ControllerBase {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public PublisherController(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetPublishers() {
			GetPublishersQuery query = new GetPublishersQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetPublisher(int id) {
			GetPublisherViewModel result;
			GetPublisherQuery query = new GetPublisherQuery(context, mapper);
			query.PublisherID = id;
			GetPublisherQueryValidator validator = new GetPublisherQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreatePublisher([FromBody] CreatePublisherModel create_publisher_model) {
			CreatePublisherCommand command = new CreatePublisherCommand(context, mapper);
			command.Model = create_publisher_model;
			CreatePublisherCommandValidator validator = new CreatePublisherCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdatePublisher(int id, [FromBody] UpdatePublisherModel update_publisher_model) {
			UpdatePublisherCommand command = new UpdatePublisherCommand(context);
			command.PublisherID = id;
			command.Model = update_publisher_model;
			UpdatePublisherCommandValidator validator = new UpdatePublisherCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeletePublisher(int id) {
			DeletePublisherCommand command = new DeletePublisherCommand(context);
			command.PublisherID = id;
			DeletePublisherCommandValidator validator = new DeletePublisherCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}