using FluentValidation;
namespace movie_store.Application.CustomerOperations.Commands.CreateCustomer {
	public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand> {
		public CreateCustomerCommandValidator() {
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
		}
	}
}