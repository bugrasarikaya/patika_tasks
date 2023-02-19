using FluentValidation;
namespace game_store.Application.GameOperations.Commands.DeleteGame {
	public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand> {
		public DeleteGameCommandValidator() {
			RuleFor(command => command.GameID).GreaterThan(0);
		}
	}
}