using FluentValidation;
namespace movie_store.Application.ActorOperations.Commands.UpdateActor {
	public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand> {
		public UpdateActorCommandValidator() {
			RuleFor(command => command.ActorID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.MovieIDs).NotNull();
			RuleForEach(command => command.Model.MovieIDs).GreaterThan(0);
		}
	}
}