using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using movie_store.Application.OrderOperations.Commands.CreateOrder;
using movie_store.Application.OrderOperations.Queries.GetOrders;
using movie_store.Application.OrderOperations.Queries.GetOrder;
using movie_store.DBOperations;
using static movie_store.Application.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
using static movie_store.Application.OrderOperations.Queries.GetOrder.GetOrderQuery;
namespace Order_store.Controllers {
	[ApiController]
	[Route("[controller]s")]
	public class OrderController : ControllerBase {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public OrderController(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		[HttpGet]
		public IActionResult GetOrders() {
			GetOrdersQuery query = new GetOrdersQuery(context, mapper);
			var result = query.Handle();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public IActionResult GetOrder(int id) {
			GetOrderViewModel result;
			GetOrderQuery query = new GetOrderQuery(context, mapper);
			query.OrderID = id;
			GetOrderQueryValidator validator = new GetOrderQueryValidator();
			validator.ValidateAndThrow(query);
			result = query.Handle();
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateOrder([FromBody] CreateOrderModel create_order_model) {
			CreateOrderCommand command = new CreateOrderCommand(context);
			command.Model = create_order_model;
			CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
			validator.ValidateAndThrow(command);
			command.Handle();
			return Ok();
		}
	}
}