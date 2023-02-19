using FluentValidation;
namespace game_store.Application.PublisherOperations.Queries.GetPublisher {
	public class GetPublisherQueryValidator : AbstractValidator<GetPublisherQuery> {
		public GetPublisherQueryValidator() {
			RuleFor(command => command.PublisherID).GreaterThan(0);
		}
	}
}