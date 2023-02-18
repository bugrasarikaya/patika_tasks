using FluentAssertions;
using movie_store.Application.GenreOperations.Queries.GetGenre;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Queries.GetGenre {
	public class GetGenreQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int genre_ID) {
			GetGenreQuery query = new GetGenreQuery(null, null);
			query.GenreID = genre_ID;
			GetGenreQueryValidator validator = new GetGenreQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int genre_ID) {
			GetGenreQuery query = new GetGenreQuery(null, null);
			query.GenreID = genre_ID;
			GetGenreQueryValidator validator = new GetGenreQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}