using FluentValidation;
namespace task_4.Application.GenreOperations.UpdateGenre {
	public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {
		public UpdateGenreCommandValidator() {
			RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name.Trim() != string.Empty);
		}
	}
}