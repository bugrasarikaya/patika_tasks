using FluentValidation;
namespace task_4.Application.GenreOperations.Queries.GetGenreDetail {
	public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery> {
		public GetGenreDetailQueryValidator() {
			RuleFor(query => query.GenreID).GreaterThan(0);
		}
	}
}