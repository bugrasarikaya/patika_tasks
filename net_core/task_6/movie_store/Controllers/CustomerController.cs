using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using movie_store.Application.CustomerOperations.Commands.CreateCustomer;
using movie_store.Application.CustomerOperations.Queries.GetCustomers;
using movie_store.Application.CustomerOperations.Queries.GetCustomer;
using movie_store.Application.CustomerOperations.Commands.UpdateCustomer;
using movie_store.Application.CustomerOperations.Commands.DeleteCustomer;
using movie_store.DBOperations;
using static movie_store.Application.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
using static movie_store.Application.CustomerOperations.Commands.UpdateCustomer.UpdateCustomerCommand;
using static movie_store.Application.CustomerOperations.Queries.GetCustomer.GetCustomerQuery;
namespace Customer_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class CustomerController : ControllerBase {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public CustomerController(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetCustomers() {
			GetCustomersQuery query = new GetCustomersQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetCustomer(int id) {
			GetCustomerViewModel result;
			GetCustomerQuery query = new GetCustomerQuery(context, mapper);
			query.CustomerID = id;
			GetCustomerQueryValidator validator = new GetCustomerQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateCustomer([FromBody] CreateCustomerModel create_customer_model) {
			CreateCustomerCommand command = new CreateCustomerCommand(context, mapper);
			command.Model = create_customer_model;
			CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerModel update_customer_model) {
			UpdateCustomerCommand command = new UpdateCustomerCommand(context);
			command.CustomerID = id;
			command.Model = update_customer_model;
			UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteCustomer(int id) {
			DeleteCustomerCommand command = new DeleteCustomerCommand(context);
			command.CustomerID = id;
			DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}