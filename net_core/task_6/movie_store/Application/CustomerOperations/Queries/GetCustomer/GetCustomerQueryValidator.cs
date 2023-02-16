using FluentValidation;
namespace movie_store.Application.CustomerOperations.Queries.GetCustomer {
	public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery> {
		public GetCustomerQueryValidator() {
			RuleFor(command => command.CustomerID).GreaterThan(0);
		}
	}
}