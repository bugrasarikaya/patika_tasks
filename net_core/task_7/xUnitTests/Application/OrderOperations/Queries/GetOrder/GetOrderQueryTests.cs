using AutoMapper;
using FluentAssertions;
using game_store.Application.OrderOperations.Queries.GetOrder;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.OrderOperations.Queries.GetOrder {
	public class GetOrderDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public GetOrderDetailQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistOrderIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetOrderQuery query = new GetOrderQuery(context, mapper);
			query.OrderID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Order could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Order_ShouldBeReturn() {
			GetOrderQuery query = new GetOrderQuery(context, mapper);
			query.OrderID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Order? order = context.Orders.SingleOrDefault(o => o.ID == query.OrderID);
			order.Should().NotBeNull();
		}
	}
}