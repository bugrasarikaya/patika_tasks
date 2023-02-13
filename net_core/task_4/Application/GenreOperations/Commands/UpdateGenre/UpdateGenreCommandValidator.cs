using FluentValidation;
namespace task_4.Application.GenreOperations.Commands.UpdateGenre {
	public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {
		public UpdateGenreCommandValidator() {
			RuleFor(command => command.Model.Name).MinimumLength(4);
		}
	}
}