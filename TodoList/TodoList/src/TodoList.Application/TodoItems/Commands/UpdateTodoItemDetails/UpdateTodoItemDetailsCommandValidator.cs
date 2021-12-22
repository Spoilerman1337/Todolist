using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItemDetails
{
    public class UpdateTodoItemDetailsCommandValidator : AbstractValidator<UpdateTodoItemDetailsCommand>
    {
        public UpdateTodoItemDetailsCommandValidator()
        {
            RuleFor(v => v.Id).NotEqual(Guid.Empty);
            RuleFor(v => v.Note).MaximumLength(500);
        }
    }
}
