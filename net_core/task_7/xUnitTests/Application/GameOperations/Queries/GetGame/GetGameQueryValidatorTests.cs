using FluentAssertions;
using game_store.Application.GameOperations.Queries.GetGame;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GameOperations.Queries.GetGame {
	public class GetGameQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int game_ID) {
			GetGameQuery query = new GetGameQuery(null, null);
			query.GameID = game_ID;
			GetGameQueryValidator validator = new GetGameQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int game_ID) {
			GetGameQuery query = new GetGameQuery(null, null);
			query.GameID = game_ID;
			GetGameQueryValidator validator = new GetGameQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}