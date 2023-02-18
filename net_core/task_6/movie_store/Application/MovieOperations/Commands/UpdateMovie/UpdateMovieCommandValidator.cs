using FluentValidation;
namespace movie_store.Application.MovieOperations.Commands.UpdateMovie {
	public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand> {
		public UpdateMovieCommandValidator() {
			RuleFor(command => command.MovieID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
			RuleFor(command => command.Model.Price).GreaterThan(0.00);
			RuleFor(command => command.Model.ActorIDs).NotNull();
			RuleForEach(command => command.Model.ActorIDs).GreaterThan(0);
			RuleFor(command => command.Model.DirectorIDs).NotNull();
			RuleForEach(command => command.Model.DirectorIDs).GreaterThan(0);
			RuleFor(command => command.Model.GenreIDs).NotNull();
			RuleForEach(command => command.Model.GenreIDs).GreaterThan(0);
		}
	}
}