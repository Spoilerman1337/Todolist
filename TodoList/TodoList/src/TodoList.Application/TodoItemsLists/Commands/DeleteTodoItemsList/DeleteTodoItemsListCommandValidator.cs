using FluentValidation;
using System;

namespace TodoList.Application.TodoItemsLists.Commands.DeleteTodoItemsList
{
    public class DeleteTodoItemsListCommandValidator : AbstractValidator<DeleteTodoItemsListCommand>
    {
        public DeleteTodoItemsListCommandValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("ID is required.");
        }
    }
}
