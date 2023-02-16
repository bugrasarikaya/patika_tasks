using FluentValidation;
namespace movie_store.Application.DirectorOperations.Queries.GetDirector {
	public class GetDirectorQueryValidator : AbstractValidator<GetDirectorQuery> {
		public GetDirectorQueryValidator() {
			RuleFor(command => command.DirectorID).GreaterThan(0);
		}
	}
}