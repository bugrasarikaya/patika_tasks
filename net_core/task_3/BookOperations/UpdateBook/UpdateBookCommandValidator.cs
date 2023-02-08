using FluentValidation;
namespace task_3.BookOperations.UpdateBook {
	public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> {
		public UpdateBookCommandValidator() {
			RuleFor(command => command.Model.GenreID).GreaterThan(0);
			RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
		}
	}
}