using FluentValidation;
namespace game_store.Application.PublisherOperations.Commands.UpdatePublisher {
	public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand> {
		public UpdatePublisherCommandValidator() {
			RuleFor(command => command.PublisherID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
		}
	}
}