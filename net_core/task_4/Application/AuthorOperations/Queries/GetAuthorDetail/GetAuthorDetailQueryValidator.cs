using FluentValidation;
namespace task_4.Application.AuthorOperations.Queries.GetAuthorDetail {
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery> {
        public GetAuthorDetailQueryValidator() {
            RuleFor(command => command.AuthorID).GreaterThan(0);
        }
    }
}