using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoItemsLists.Commands.UpdateTodoItemsList
{
    public class UpdateTodoItemsListCommandHandler : IRequestHandler<UpdateTodoItemsListCommand>
    {
        private readonly ITodoListDbContext _context;

        public UpdateTodoItemsListCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;

        public async Task<Unit> Handle(UpdateTodoItemsListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
