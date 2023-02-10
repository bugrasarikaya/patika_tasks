using FluentValidation;
namespace task_4.Application.GenreOperations.Commands.CreateGenre {
	public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand> {
		public CreateGenreCommandValidator() {
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
		}
	}
}