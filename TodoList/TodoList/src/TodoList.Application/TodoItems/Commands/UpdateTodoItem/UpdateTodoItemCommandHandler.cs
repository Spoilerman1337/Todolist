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
            var entity = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        
    }
}
