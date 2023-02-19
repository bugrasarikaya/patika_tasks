using FluentValidation;
namespace game_store.Application.GameOperations.Commands.CreateGame {
	public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand> {
		public CreateGameCommandValidator() {
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
			RuleFor(command => command.Model.Price).GreaterThan(0.00);
		}
	}
}