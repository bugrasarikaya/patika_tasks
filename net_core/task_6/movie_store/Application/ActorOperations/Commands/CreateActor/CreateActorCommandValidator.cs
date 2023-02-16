using FluentValidation;
namespace movie_store.Application.ActorOperations.Commands.CreateActor {
	public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand> {
		public CreateActorCommandValidator() {
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
		}
	}
}