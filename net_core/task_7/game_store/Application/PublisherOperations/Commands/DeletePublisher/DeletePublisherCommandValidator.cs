using FluentValidation;
namespace game_store.Application.PublisherOperations.Commands.DeletePublisher {
	public class DeletePublisherCommandValidator : AbstractValidator<DeletePublisherCommand> {
		public DeletePublisherCommandValidator() {
			RuleFor(command => command.PublisherID).GreaterThan(0);
		}
	}
}