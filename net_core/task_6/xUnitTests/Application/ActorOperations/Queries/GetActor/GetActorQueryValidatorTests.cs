using FluentAssertions;
using movie_store.Application.ActorOperations.Queries.GetActor;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.ActorOperations.Queries.GetActor {
	public class GetActorQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int actor_ID) {
			GetActorQuery query = new GetActorQuery(null, null);
			query.ActorID = actor_ID;
			GetActorQueryValidator validator = new GetActorQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int actor_ID) {
			GetActorQuery query = new GetActorQuery(null, null);
			query.ActorID = actor_ID;
			GetActorQueryValidator validator = new GetActorQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}