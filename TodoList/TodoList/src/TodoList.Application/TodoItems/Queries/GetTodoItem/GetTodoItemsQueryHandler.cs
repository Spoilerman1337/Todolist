using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem;

public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, List<TodoItemDto>>
{
    private readonly IMapper _mapper;
    private readonly ITodoListDbContext _context;

    public GetTodoItemsQueryHandler(ITodoListDbContext dbContext, IMapper mapper) => (_mapper, _context) = (mapper, dbContext);

    public async Task<List<TodoItemDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Id)
            .ProjectTo<TodoItemDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
