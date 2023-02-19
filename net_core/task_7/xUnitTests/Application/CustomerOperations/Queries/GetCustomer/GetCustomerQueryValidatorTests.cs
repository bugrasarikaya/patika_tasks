using FluentAssertions;
using game_store.Application.CustomerOperations.Queries.GetCustomer;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.CustomerOperations.Queries.GetCustomer {
	public class GetCustomerQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int customer_ID) {
			GetCustomerQuery query = new GetCustomerQuery(null, null);
			query.CustomerID = customer_ID;
			GetCustomerQueryValidator validator = new GetCustomerQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int customer_ID) {
			GetCustomerQuery query = new GetCustomerQuery(null, null);
			query.CustomerID = customer_ID;
			GetCustomerQueryValidator validator = new GetCustomerQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}