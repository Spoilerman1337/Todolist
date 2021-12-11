using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly ITodoListDbContext _context;

        public DeleteTodoItemCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;
        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), cancellationToken);
            }

            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
