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
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(IsUniqueTitle).WithMessage("Name must be unique.");
            RuleFor(v => v.Description)
                .MaximumLength(500).WithMessage("Name must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueTitle(string name, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.AllAsync(v => v.Name != name, cancellationToken);
        }
    }
}
