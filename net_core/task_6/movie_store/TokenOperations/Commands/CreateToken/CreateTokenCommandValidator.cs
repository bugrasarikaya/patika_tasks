using FluentValidation;
namespace movie_store.TokenOperations.Commands.CreateToken {
	public class CreateTokenCommandValidator : AbstractValidator<CreateTokenCommand> {
		public CreateTokenCommandValidator() {
			RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(8);
			RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(8);
		}
	}
}