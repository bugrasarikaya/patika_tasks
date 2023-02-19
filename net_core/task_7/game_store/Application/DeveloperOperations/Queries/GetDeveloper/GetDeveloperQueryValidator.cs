using FluentValidation;
namespace game_store.Application.DeveloperOperations.Queries.GetDeveloper {
	public class GetDeveloperQueryValidator : AbstractValidator<GetDeveloperQuery> {
		public GetDeveloperQueryValidator() {
			RuleFor(command => command.DeveloperID).GreaterThan(0);
		}
	}
}