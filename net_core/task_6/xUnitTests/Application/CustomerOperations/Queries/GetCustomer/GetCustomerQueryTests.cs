using AutoMapper;
using FluentAssertions;
using movie_store.Application.CustomerOperations.Queries.GetCustomer;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.CustomerOperations.Queries.GetCustomer {
	public class GetCustomerQueryTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetCustomerQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistCustomerIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetCustomerQuery query = new GetCustomerQuery(context, mapper);
			query.CustomerID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Customer could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Customer_ShouldBeReturn() {
			GetCustomerQuery query = new GetCustomerQuery(context, mapper);
			query.CustomerID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == query.CustomerID);
			customer.Should().NotBeNull();
		}
	}
}