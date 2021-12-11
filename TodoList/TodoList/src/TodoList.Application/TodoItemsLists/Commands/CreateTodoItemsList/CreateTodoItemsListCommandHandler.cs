using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItemsLists.Commands.CreateTodoItemsList
{
    public class CreateTodoItemsListCommandHandler : IRequestHandler<CreateTodoItemsListCommand, Guid>
    {
        private readonly ITodoListDbContext _context;

        public CreateTodoItemsListCommandHandler(ITodoListDbContext dbContext) => _context = dbContext;

        public async Task<Guid> Handle(CreateTodoItemsListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItemsList
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                LastEditDate = DateTime.Now
            };

            _context.TodoLists.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
