using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly ITodoListDbContext _context;

        public UpdateTodoItemCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;

        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(new object[] {request.Id}, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.Title = request.Title;
            entity.IsDone = request.IsDone;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
