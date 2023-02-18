using FluentValidation;
namespace movie_store.Application.DirectorOperations.Commands.UpdateDirector {
	public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand> {
		public UpdateDirectorCommandValidator() {
			RuleFor(command => command.DirectorID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
		}
	}
}