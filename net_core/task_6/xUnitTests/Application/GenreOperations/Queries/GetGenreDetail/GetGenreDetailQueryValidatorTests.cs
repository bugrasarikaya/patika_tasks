using FluentAssertions;
using movie_store.Application.GenreOperations.Queries.GetGenreDetail;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GenreOperations.Queries.GetGenreDetail {
	public class GetGenreDetailQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int GenreID) {
			GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
			query.GenreID = GenreID;
			GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int GenreID) {
			GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
			query.GenreID = GenreID;
			GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}