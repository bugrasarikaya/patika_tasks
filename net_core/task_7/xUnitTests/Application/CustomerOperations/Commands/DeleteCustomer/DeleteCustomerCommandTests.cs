using FluentAssertions;
using game_store.Application.CustomerOperations.Commands.DeleteCustomer;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.CustomerOperations.Commands.DeleteCustomer {
	public class DeleteCustomerCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public DeleteCustomerCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistCustomerIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			DeleteCustomerCommand command = new DeleteCustomerCommand(context);
			command.CustomerID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Customer_ShouldBeDeleted() {
			DeleteCustomerCommand command = new DeleteCustomerCommand(context);
			command.CustomerID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Customer? result_customer = context.Customers.SingleOrDefault(c => c.ID == command.CustomerID);
			result_customer.Should().BeNull();
		}
	}
}