using FluentValidation;
namespace task_4.Application.AuthorOperations.Commands.DeleteAuthor {
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand> {
        public DeleteAuthorCommandValidator() {
            RuleFor(command => command.AuthorID).GreaterThan(0);
        }
    }
}