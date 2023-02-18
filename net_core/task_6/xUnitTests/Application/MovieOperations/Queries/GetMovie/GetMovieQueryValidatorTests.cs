using FluentAssertions;
using movie_store.Application.MovieOperations.Queries.GetMovie;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.MovieOperations.Queries.GetMovie {
	public class GetMovieQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int movie_ID) {
			GetMovieQuery query = new GetMovieQuery(null, null);
			query.MovieID = movie_ID;
			GetMovieQueryValidator validator = new GetMovieQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int movie_ID) {
			GetMovieQuery query = new GetMovieQuery(null, null);
			query.MovieID = movie_ID;
			GetMovieQueryValidator validator = new GetMovieQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}