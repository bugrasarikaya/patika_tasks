using FluentValidation;
namespace movie_store.Application.GenreOperations.Queries.GetGenre {
	public class GetGenreQueryValidator : AbstractValidator<GetGenreQuery> {
		public GetGenreQueryValidator() {
			RuleFor(command => command.GenreID).GreaterThan(0);
		}
	}
}