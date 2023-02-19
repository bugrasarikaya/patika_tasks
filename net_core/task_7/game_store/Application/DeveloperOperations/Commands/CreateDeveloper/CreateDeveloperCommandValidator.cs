using FluentValidation;
namespace game_store.Application.DeveloperOperations.Commands.CreateDeveloper {
	public class CreateDeveloperCommandValidator : AbstractValidator<CreateDeveloperCommand> {
		public CreateDeveloperCommandValidator() {
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
		}
	}
}