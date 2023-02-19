using FluentAssertions;
using game_store.Application.OrderOperations.Queries.GetOrder;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.OrderOperations.Queries.GetOrder {
	public class GetOrderQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int order_ID) {
			GetOrderQuery query = new GetOrderQuery(null, null);
			query.OrderID = order_ID;
			GetOrderQueryValidator validator = new GetOrderQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int order_ID) {
			GetOrderQuery query = new GetOrderQuery(null, null);
			query.OrderID = order_ID;
			GetOrderQueryValidator validator = new GetOrderQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}