using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoItemsLists.Queries.GetTodoItemsList;

public class GetTodoItemsListQueryHandler : IRequestHandler<GetTodoItemsListQuery, TodoItemsListVm>
{
    private readonly ITodoListDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsListQueryHandler(ITodoListDbContext dbContext, IMapper mapper) => (_context, _mapper) = (dbContext, mapper);

    public async Task<TodoItemsListVm> Handle(GetTodoItemsListQuery request, CancellationToken cancellationToken)
    {
        var todoItemsListQuery = await _context.TodoLists
            .ProjectTo<TodoItemsListDto>(_mapper.ConfigurationProvider)
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken);

        return new TodoItemsListVm { Lists = todoItemsListQuery };
    }
}
