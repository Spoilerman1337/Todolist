using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItemDetails;

    public class UpdateTodoItemDetailsCommandHandler : IRequestHandler<UpdateTodoItemDetailsCommand>
{
    private readonly ITodoListDbContext _context;

    public UpdateTodoItemDetailsCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;

    public async Task<Unit> Handle(UpdateTodoItemDetailsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        entity.Note = request.Note;
        entity.PriorityLevel = request.PriorityLevel;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
