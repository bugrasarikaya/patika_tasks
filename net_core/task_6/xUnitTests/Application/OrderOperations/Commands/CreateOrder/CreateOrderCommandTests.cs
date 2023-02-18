using FluentAssertions;
using movie_store.Application.OrderOperations.Commands.CreateOrder;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
namespace xUnitTests.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		public CreateOrderCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistCustomerIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			CreateOrderCommand command = new CreateOrderCommand(context);
			CreateOrderModel model = new CreateOrderModel() { CustomerID = 0, MovieIDs = new List<int>() { 1 } };
			command.Model = model;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer could not be found.");
		}
		[Fact]
		public void WhenNotExistMovieIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			CreateOrderCommand command = new CreateOrderCommand(context);
			CreateOrderModel model = new CreateOrderModel() { CustomerID = 1, MovieIDs = new List<int>() { 0 } };
			command.Model = model;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Movie could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Order_ShouldBeCreated() {
			CreateOrderCommand command = new CreateOrderCommand(context);
			CreateOrderModel model = new CreateOrderModel() { CustomerID = 1, MovieIDs = new List<int>() { 1 } };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Order? order = context.Orders.SingleOrDefault(o => o.ID == command.Order.ID);
			order.Should().NotBeNull();
			order?.CustomerID.Should().Be(model.CustomerID);
			order?.Customer.Should().Be(string.Format("{0} {1}", context.Customers.SingleOrDefault(c => c.ID == command.Model.CustomerID)?.Name, context.Customers.SingleOrDefault(c => c.ID == command.Model.CustomerID)?.Surname));
			order?.CustomerEmail.Should().Be(context.Customers.SingleOrDefault(c => c.ID == command.Model.CustomerID)?.Email);
			order?.DateTime.Should().BeBefore(DateTime.Now);
			double cost = 0.0;
			foreach (int movie_id in command.Model.MovieIDs) cost += context.Movies.SingleOrDefault(c => c.ID == movie_id)!.Price;
			order?.Cost.Should().Be(cost);
			List<OrderMovie>? list_order_movie = context.OrderMovies.Where(om => om.OrderID == command.Order.ID).ToList();
			list_order_movie.Should().NotBeNull();
			list_order_movie.Count.Should().Be(command.Model.MovieIDs.Count);
			for (int i = 0; i < list_order_movie.Count; i++) list_order_movie[0].MovieID.Should().Be(command.Model.MovieIDs[i]);
		}
	}
}