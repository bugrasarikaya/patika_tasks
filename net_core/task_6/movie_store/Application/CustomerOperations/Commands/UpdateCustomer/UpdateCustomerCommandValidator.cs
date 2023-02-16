using FluentValidation;
namespace movie_store.Application.CustomerOperations.Commands.UpdateCustomer {
	public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand> {
		public UpdateCustomerCommandValidator() {
			RuleFor(command => command.CustomerID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.MovieIDs).NotNull();
			RuleForEach(command => command.Model.MovieIDs).GreaterThan(0);
			RuleFor(command => command.Model.GenreIDs).NotNull();
			RuleForEach(command => command.Model.GenreIDs).GreaterThan(0);
		}
	}
}