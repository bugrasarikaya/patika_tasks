using FluentValidation;
namespace game_store.Application.GameOperations.Commands.UpdateGame {
	public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand> {
		public UpdateGameCommandValidator() {
			RuleFor(command => command.GameID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
			RuleFor(command => command.Model.Price).GreaterThan(0.00);
			RuleFor(command => command.Model.DeveloperIDs).NotNull();
			RuleForEach(command => command.Model.DeveloperIDs).GreaterThan(0);
			RuleFor(command => command.Model.PublisherIDs).NotNull();
			RuleForEach(command => command.Model.PublisherIDs).GreaterThan(0);
		}
	}
}