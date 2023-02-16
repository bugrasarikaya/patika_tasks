using FluentValidation;
namespace movie_store.Application.ActorOperations.Queries.GetActor {
	public class GetActorQueryValidator : AbstractValidator<GetActorQuery> {
		public GetActorQueryValidator() {
			RuleFor(command => command.ActorID).GreaterThan(0);
		}
	}
}