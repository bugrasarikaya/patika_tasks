using FluentValidation;
namespace movie_store.Application.MovieOperations.Commands.DeleteMovie {
	public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand> {
		public DeleteMovieCommandValidator() {
			RuleFor(command => command.MovieID).GreaterThan(0);
		}
	}
}