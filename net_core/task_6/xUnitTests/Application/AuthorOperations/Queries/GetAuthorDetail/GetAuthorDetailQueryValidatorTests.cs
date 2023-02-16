using FluentAssertions;
using movie_store.Application.AuthorOperations.Queries.GetAuthorDetail;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.AuthorOperations.Queries.GetAuthorDetail {
	public class GetAuthorDetailQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int AuthorID) {
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
			query.AuthorID = AuthorID;
			GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int AuthorID) {
			GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
			query.AuthorID = AuthorID;
			GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}