using FluentValidation;
namespace game_store.Application.DeveloperOperations.Commands.DeleteDeveloper {
	public class DeleteDeveloperCommandValidator : AbstractValidator<DeleteDeveloperCommand> {
		public DeleteDeveloperCommandValidator() {
			RuleFor(command => command.DeveloperID).GreaterThan(0);
		}
	}
}