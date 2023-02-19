using AutoMapper;
using FluentAssertions;
using game_store.Application.CustomerOperations.Commands.CreateCustomer;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
namespace xUnitTests.Application.CustomerOperations.Commands.CreateCustomer {
	public class CreateCustomerCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public CreateCustomerCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistCustomerIsGiven_InvalidOperationException_ShouldBeReturn() {
			Customer customer = new Customer() { Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			context.Customers.Add(customer);
			context.SaveChanges();
			CreateCustomerCommand command = new CreateCustomerCommand(context, mapper);
			command.Model = new CreateCustomerModel() { Email = customer.Email, Password = customer.Password };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer email already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Customer_ShouldBeCreated() {
			CreateCustomerCommand command = new CreateCustomerCommand(context, mapper);
			CreateCustomerModel model = new CreateCustomerModel() { Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Customer? customer = context.Customers.SingleOrDefault(c => c.Email == model.Email);
			customer.Should().NotBeNull();
			customer?.Email.Should().Be(model.Email);
			customer?.Password.Should().Be(model.Password);
		}
	}
}