using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Application.Common.Interfaces;

public interface ITodoListDbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoItemsList> TodoLists { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

