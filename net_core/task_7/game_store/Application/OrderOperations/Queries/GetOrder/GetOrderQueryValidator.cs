using FluentValidation;
namespace game_store.Application.OrderOperations.Queries.GetOrder {
	public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery> {
		public GetOrderQueryValidator() {
			RuleFor(command => command.OrderID).GreaterThan(0);
		}
	}
}