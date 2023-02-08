using FluentValidation;
namespace task_3.BookOperations.DeleteBook {
	public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand> {
		public DeleteBookCommandValidator() {
			RuleFor(command => command.BookID).GreaterThan(0);
		}
	}
}