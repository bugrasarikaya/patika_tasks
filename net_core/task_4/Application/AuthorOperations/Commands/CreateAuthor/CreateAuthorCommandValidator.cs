using FluentValidation;
namespace task_4.Application.AuthorOperations.Commands.CreateAuthor {
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand> {
        public CreateAuthorCommandValidator() {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.DateofBirth.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}