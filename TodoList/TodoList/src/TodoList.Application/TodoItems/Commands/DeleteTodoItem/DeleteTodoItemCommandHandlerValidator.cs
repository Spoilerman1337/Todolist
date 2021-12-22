using FluentValidation;
using System;

namespace TodoList.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandHandlerValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        public DeleteTodoItemCommandHandlerValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty);
        }
    }
}
