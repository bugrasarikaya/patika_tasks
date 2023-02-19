using FluentValidation;
namespace game_store.Application.GameOperations.Queries.GetGame {
	public class GetGameQueryValidator : AbstractValidator<GetGameQuery> {
		public GetGameQueryValidator() {
			RuleFor(command => command.GameID).GreaterThan(0);
		}
	}
}