using FluentAssertions;
using game_store.Application.CustomerOperations.Commands.UpdateCustomer;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.CustomerOperations.Commands.UpdateCustomer.UpdateCustomerCommand;
namespace xUnitTests.Application.CustomerOperations.Commands.UpadteCustomer {
	public class UpdateCustomerCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		public UpdateCustomerCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
		}
		[Fact]
		public void WhenNotExistCustomerIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateCustomerCommand command = new UpdateCustomerCommand(context);
			command.CustomerID = 0;
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer could not be found.");
		}
		[Fact]
		public void WhenAlreadyExistCustomerInfoIsGiven_InvalidOperationException_ShouldBeReturn() {
			Customer customer = new Customer() { Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			context.Customers.Add(customer);
			context.SaveChanges();
			UpdateCustomerCommand command = new UpdateCustomerCommand(context);
			command.CustomerID = 1;
			command.Model = new UpdateCustomerModel() { Email = customer.Email, Password = customer.Password };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer email already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Customer_ShouldBeUpdated() {
			UpdateCustomerCommand command = new UpdateCustomerCommand(context);
			command.Model = new UpdateCustomerModel() { Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			command.CustomerID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == command.CustomerID);
			customer.Should().NotBeNull();
		}
	}
}