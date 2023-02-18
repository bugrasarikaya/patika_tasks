using Castle.Core.Resource;
using FluentAssertions;
using movie_store.Application.CustomerOperations.Commands.UpdateCustomer;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.CustomerOperations.Commands.UpdateCustomer.UpdateCustomerCommand;
namespace xUnitTests.Application.CustomerOperations.Commands.UpadteCustomer {
	public class UpdateCustomerCommandTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
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
			Customer customer = new Customer() { Name = "Therese", Surname = "Voerman", Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			context.Customers.Add(customer);
			context.SaveChanges();
			UpdateCustomerCommand command = new UpdateCustomerCommand(context);
			command.CustomerID = 1;
			command.Model = new UpdateCustomerModel() { Name = customer.Name, Surname = customer.Surname, Email = customer.Email, Password = customer.Password, GenreIDs = new List<int>() { 1 } };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer email already exists.");
		}
		[Fact]
		public void WhenNotExistGenreIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			UpdateCustomerCommand command = new UpdateCustomerCommand(context);
			command.CustomerID = 1;
			command.Model = new UpdateCustomerModel() { Name = "Therese", Surname = "Voerman", Email = "theresevoerman@schrecknet.vtm", Password = "12345678", GenreIDs = new List<int>() { 0 } };
			FluentActions
			.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Customer_ShouldBeUpdated() {
			UpdateCustomerCommand command = new UpdateCustomerCommand(context);
			command.Model = new UpdateCustomerModel() { Name = "Therese", Surname = "Voerman", Email = "theresevoerman@schrecknet.vtm", Password = "12345678", GenreIDs = new List<int>() { 1 } };
			command.CustomerID = 1;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == command.CustomerID);
			customer.Should().NotBeNull();
			List<CustomerGenre>? list_customer_genre = context.CustomerGenres.Where(cg => cg.CustomerID == command.CustomerID).ToList();
			list_customer_genre.Should().NotBeNull();
			list_customer_genre.Count.Should().Be(command.Model.GenreIDs.Count);
			for (int i = 0; i < list_customer_genre.Count; i++) list_customer_genre[0].GenreID.Should().Be(command.Model.GenreIDs[i]);
		}
	}
}