using FluentValidation;
namespace game_store.Application.DeveloperOperations.Commands.UpdateDeveloper {
	public class UpdateDeveloperCommandValidator : AbstractValidator<UpdateDeveloperCommand> {
		public UpdateDeveloperCommandValidator() {
			RuleFor(command => command.DeveloperID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
		}
	}
}