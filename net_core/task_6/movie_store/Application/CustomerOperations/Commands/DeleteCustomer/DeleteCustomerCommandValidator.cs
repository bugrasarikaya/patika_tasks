using FluentValidation;
namespace movie_store.Application.CustomerOperations.Commands.DeleteCustomer {
	public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand> {
		public DeleteCustomerCommandValidator() {
			RuleFor(command => command.CustomerID).GreaterThan(0);
		}
	}
}