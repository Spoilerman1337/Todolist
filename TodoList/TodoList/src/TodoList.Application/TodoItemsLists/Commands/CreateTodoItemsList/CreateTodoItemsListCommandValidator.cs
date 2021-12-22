using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoItemsLists.Commands.CreateTodoItemsList
{
    public class CreateTodoItemsListCommandValidator : AbstractValidator<CreateTodoItemsListCommand>
    {
        private readonly ITodoListDbContext _context;

        public CreateTodoItemsListCommandValidator(ITodoListDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title must not exceed 500 characters.")
                .MustAsync(IsUniqueTitle).WithMessage("Title name must be unique");
        }

        private async Task<bool> IsUniqueTitle(string name, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.AllAsync(v => v.Name != name, cancellationToken);
        }
    }
}
