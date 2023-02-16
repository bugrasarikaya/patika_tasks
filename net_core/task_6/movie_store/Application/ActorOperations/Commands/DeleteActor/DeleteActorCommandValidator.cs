using FluentValidation;
namespace movie_store.Application.ActorOperations.Commands.DeleteActor {
	public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand> {
		public DeleteActorCommandValidator() {
			RuleFor(command => command.ActorID).GreaterThan(0);
		}
	}
}