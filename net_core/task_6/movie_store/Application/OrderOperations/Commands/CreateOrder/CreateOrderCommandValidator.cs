using FluentValidation;
namespace movie_store.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> {
		public CreateOrderCommandValidator() {
			RuleFor(command => command.Model.CustomerID).GreaterThan(0);
			RuleFor(command => command.Model.MovieIDs).NotNull();
			RuleForEach(command => command.Model.MovieIDs).GreaterThan(0);
		}
	}
}