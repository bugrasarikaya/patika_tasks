using FluentAssertions;
using task_4.Application.BookOperations.Queries.GetBookDetail;
using task_5.TestSetup;
namespace task_5.Application.BookOperations.Queries.GetBookDetail {
	public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int bookID) {
			GetBookDetailQuery query = new GetBookDetailQuery(null, null);
			query.BookID = bookID;
			GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int bookID) {
			GetBookDetailQuery query = new GetBookDetailQuery(null, null);
			query.BookID = bookID;
			GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
			var result = validator.Validate(query);
			result.Errors.Count.Should().Be(0);
		}
	}
}