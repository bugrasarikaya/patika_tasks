using FluentValidation;
namespace task_4.Application.GenreOperations.Commands.DeleteGenre {
	public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand> {
		public DeleteGenreCommandValidator() {
			RuleFor(command => command.GenreID).GreaterThan(0);
		}
	}
}