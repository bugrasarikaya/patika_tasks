using FluentValidation;
namespace movie_store.Application.MovieOperations.Queries.GetMovie {
	public class GetMovieQueryValidator : AbstractValidator<GetMovieQuery> {
		public GetMovieQueryValidator() {
			RuleFor(command => command.MovieID).GreaterThan(0);
		}
	}
}