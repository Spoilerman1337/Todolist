using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemsQueryValidator : AbstractValidator<GetTodoItemsQuery>
    {
        public GetTodoItemsQueryValidator()
        {
            RuleFor(v => v.ListId).NotEmpty().WithMessage("ListId is required.");
        }
    }
}
