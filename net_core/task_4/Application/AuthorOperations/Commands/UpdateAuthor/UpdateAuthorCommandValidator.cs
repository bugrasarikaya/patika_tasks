using FluentValidation;
namespace task_4.Application.AuthorOperations.Commands.UpdateAuthor {
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand> {
        public UpdateAuthorCommandValidator() {
            RuleFor(command => command.AuthorID).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.DateofBirth.Date).NotEmpty().LessThan(DateTime.Now.Date);
		}
    }
}