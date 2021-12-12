using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoItemsLists.Commands.DeleteTodoItemsList
{
    public class DeleteTodoItemsListCommandHandler : IRequestHandler<DeleteTodoItemsListCommand>
    {
        private readonly ITodoListDbContext _context;

        public DeleteTodoItemsListCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;

        public async Task<Unit> Handle(DeleteTodoItemsListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists.FindAsync(new object[] { request.Id });
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            _context.TodoLists.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
