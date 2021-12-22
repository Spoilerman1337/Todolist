using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
    {
        private readonly ITodoListDbContext _context;

        public CreateTodoItemCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;

        public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                IsDone = false,
                Id = Guid.NewGuid()
            };

            _context.TodoItems.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
