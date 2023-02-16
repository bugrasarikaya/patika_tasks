using FluentValidation;
namespace movie_store.Application.MovieOperations.Commands.CreateMovie {
	public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand> {
		public CreateMovieCommandValidator() {
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
			RuleFor(command => command.Model.Year).GreaterThan(1900);
			RuleFor(command => command.Model.Price).GreaterThan(0.00);
		}
	}
}