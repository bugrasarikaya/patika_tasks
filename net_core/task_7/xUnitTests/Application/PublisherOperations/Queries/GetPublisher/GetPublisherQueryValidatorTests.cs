using FluentAssertions;
using game_store.Application.PublisherOperations.Queries.GetPublisher;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.PublisherOperations.Queries.GetPublisher {
	public class GetPublisherQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int publisher_ID) {
			GetPublisherQuery query = new GetPublisherQuery(null, null);
			query.PublisherID = publisher_ID;
			GetPublisherQueryValidator validator = new GetPublisherQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int publisher_ID) {
			GetPublisherQuery query = new GetPublisherQuery(null, null);
			query.PublisherID = publisher_ID;
			GetPublisherQueryValidator validator = new GetPublisherQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}