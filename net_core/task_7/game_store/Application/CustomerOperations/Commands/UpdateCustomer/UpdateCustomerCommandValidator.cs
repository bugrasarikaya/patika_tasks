using FluentValidation;
namespace game_store.Application.CustomerOperations.Commands.UpdateCustomer {
	public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand> {
		public UpdateCustomerCommandValidator() {
			RuleFor(command => command.CustomerID).GreaterThan(0);
			RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(8);
			RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(8);
		}
	}
}