using FluentValidation;
namespace game_store.Application.PublisherOperations.Commands.CreatePublisher {
	public class CreatePublisherCommandValidator : AbstractValidator<CreatePublisherCommand> {
		public CreatePublisherCommandValidator() {
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
		}
	}
}