using FluentValidation;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemsQueryValidator : AbstractValidator<GetTodoItemsQuery>
    {
        public GetTodoItemsQueryValidator()
        {
            RuleFor(v => v.ListId).NotEmpty().WithMessage("List ID is required.");
        }
    }
}
