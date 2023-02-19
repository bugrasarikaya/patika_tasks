using FluentAssertions;
using game_store.Application.DeveloperOperations.Queries.GetDeveloper;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DeveloperOperations.Queries.GetDeveloper {
	public class GetDeveloperQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int developer_ID) {
			GetDeveloperQuery query = new GetDeveloperQuery(null, null);
			query.DeveloperID = developer_ID;
			GetDeveloperQueryValidator validator = new GetDeveloperQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int developer_ID) {
			GetDeveloperQuery query = new GetDeveloperQuery(null, null);
			query.DeveloperID = developer_ID;
			GetDeveloperQueryValidator validator = new GetDeveloperQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}