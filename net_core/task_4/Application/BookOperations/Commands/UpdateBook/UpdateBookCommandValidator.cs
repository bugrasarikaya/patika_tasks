using FluentValidation;
namespace task_4.Application.BookOperations.Commands.UpdateBook {
	public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> {
		public UpdateBookCommandValidator() {
			RuleFor(command => command.BookID).GreaterThan(0);
			RuleFor(command => command.Model.AuthorID).GreaterThan(0);
			RuleFor(command => command.Model.GenreID).GreaterThan(0);
			RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
		}
	}
}