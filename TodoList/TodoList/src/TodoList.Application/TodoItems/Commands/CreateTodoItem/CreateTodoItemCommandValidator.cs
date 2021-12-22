using FluentValidation;
using System;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters.");
            RuleFor(v => v.ListId).NotEqual(Guid.Empty).WithMessage("List ID is required.");
        }
    }
}
