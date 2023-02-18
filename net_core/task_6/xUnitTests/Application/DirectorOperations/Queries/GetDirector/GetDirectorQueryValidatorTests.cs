using FluentAssertions;
using movie_store.Application.DirectorOperations.Queries.GetDirector;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DirectorOperations.Queries.GetDirector {
	public class GetDirectorQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int director_ID) {
			GetDirectorQuery query = new GetDirectorQuery(null, null);
			query.DirectorID = director_ID;
			GetDirectorQueryValidator validator = new GetDirectorQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int director_ID) {
			GetDirectorQuery query = new GetDirectorQuery(null, null);
			query.DirectorID = director_ID;
			GetDirectorQueryValidator validator = new GetDirectorQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}