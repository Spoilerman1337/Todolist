using FluentValidation;
using System;
using TodoList.Application.TodoItems.CreateTodoItem.Commands;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemsListCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemsListCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ListId).NotEqual(Guid.Empty);
        }
    }
}
