using FluentValidation;
namespace movie_store.Application.DirectorOperations.Commands.DeleteDirector {
	public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand> {
		public DeleteDirectorCommandValidator() {
			RuleFor(command => command.DirectorID).GreaterThan(0);
		}
	}
}