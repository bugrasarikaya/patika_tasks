using FluentAssertions;
using movie_store.Application.CustomerOperations.Commands.DeleteCustomer;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.CustomerOperations.Commands.DeleteCustomer {
	public class DeleteCustomerCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
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
			Customer customer = new Customer() { Name = "Therese", Surname = "Voerman", Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			context.Customers.Add(customer);
			context.SaveChanges();
			command.CustomerID = customer.ID;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Customer? result_customer = context.Customers.SingleOrDefault(c => c.ID == command.CustomerID);
			result_customer.Should().BeNull();
		}
	}
}