using FluentValidation;
namespace movie_store.Application.GenreOperations.Commands.DeleteGenre {
	public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand> {
		public DeleteGenreCommandValidator() {
			RuleFor(command => command.GenreID).GreaterThan(0);
		}
	}
}