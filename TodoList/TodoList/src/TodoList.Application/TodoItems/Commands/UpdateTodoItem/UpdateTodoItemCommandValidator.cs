using FluentValidation;
using System;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        public UpdateTodoItemCommandValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty);
            RuleFor(v => v.Title).NotEmpty().MaximumLength(50);
        }
    }
}
