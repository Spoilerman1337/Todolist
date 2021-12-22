using FluentValidation;
using System;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty().MaximumLength(50);
            RuleFor(v => v.ListId).NotEqual(Guid.Empty);
        }
    }
}
