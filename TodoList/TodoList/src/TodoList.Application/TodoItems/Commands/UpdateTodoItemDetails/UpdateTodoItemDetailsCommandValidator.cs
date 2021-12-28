using FluentValidation;
using System;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItemDetails;

public class UpdateTodoItemDetailsCommandValidator : AbstractValidator<UpdateTodoItemDetailsCommand>
{
    public UpdateTodoItemDetailsCommandValidator()
    {
        RuleFor(v => v.Id).NotEqual(Guid.Empty).WithMessage("ID is required.");
        RuleFor(v => v.Note).MaximumLength(500).WithMessage("Note must not exceed 500 characters.");
    }
}

