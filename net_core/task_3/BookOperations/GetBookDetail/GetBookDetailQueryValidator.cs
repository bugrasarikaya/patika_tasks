using FluentValidation;
namespace task_3.BookOperations.GetBookDetail {
	public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery> {
		public GetBookDetailQueryValidator() {
			RuleFor(command => command.BookID).GreaterThan(0);
		}
	}
}