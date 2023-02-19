using FluentValidation;
namespace game_store.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> {
		public CreateOrderCommandValidator() {
			RuleFor(command => command.Model.CustomerID).GreaterThan(0);
			RuleForEach(command => command.Model.GameIDs).NotNull().GreaterThan(0);
		}
	}
}