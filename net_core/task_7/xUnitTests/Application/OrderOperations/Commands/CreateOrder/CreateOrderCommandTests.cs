using FluentAssertions;
using game_store.Application.OrderOperations.Commands.CreateOrder;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
namespace xUnitTests.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public CreateOrderCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistCustomerIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			CreateOrderCommand command = new CreateOrderCommand(context);
			CreateOrderModel model = new CreateOrderModel() { CustomerID = 0, GameIDs = new List<int>() { 1 } };
			command.Model = model;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer could not be found.");
		}
		[Fact]
		public void WhenNotExistGameIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			CreateOrderCommand command = new CreateOrderCommand(context);
			CreateOrderModel model = new CreateOrderModel() { CustomerID = 1, GameIDs = new List<int>() { 0 } };
			command.Model = model;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Game could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Order_ShouldBeCreated() {
			CreateOrderCommand command = new CreateOrderCommand(context);
			CreateOrderModel model = new CreateOrderModel() { CustomerID = 1, GameIDs = new List<int>() { 1 } };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Order? order = context.Orders.SingleOrDefault(o => o.ID == command.Order.ID);
			order.Should().NotBeNull();
			order?.CustomerID.Should().Be(model.CustomerID);
			order?.CustomerEmail.Should().Be(context.Customers.SingleOrDefault(c => c.ID == command.Model.CustomerID)?.Email);
			order?.DateTime.Should().BeBefore(DateTime.Now);
			double cost = 0.0;
			foreach (int game_id in command.Model.GameIDs) cost += context.Games.SingleOrDefault(g => g.ID == game_id)!.Price;
			order?.Cost.Should().Be(cost);
			List<OrderGame>? list_order_game = context.OrderGames.Where(og => og.OrderID == command.Order.ID).ToList();
			list_order_game.Should().NotBeNull();
			list_order_game.Count.Should().Be(command.Model.GameIDs.Count);
			for (int i = 0; i < list_order_game.Count; i++) list_order_game[0].GameID.Should().Be(command.Model.GameIDs[i]);
		}
	}
}