using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoItemsLists.Commands.DeleteTodoItemsList
{
    public class DeleteTodoItemsListCommandHandler : IRequestHandler<DeleteTodoItemsListCommand>
    {
        private readonly ITodoListDbContext _context;

        public DeleteTodoItemsListCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;

        public async Task<Unit> Handle(DeleteTodoItemsListCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.TodoLists.FindAsync(new object[] { request.Id });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
