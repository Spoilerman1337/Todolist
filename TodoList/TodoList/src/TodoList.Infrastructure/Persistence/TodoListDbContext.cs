using Microsoft.EntityFrameworkCore;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Persistence.Configuration;

namespace TodoList.Infrastructure.Persistence;

public class TodoListDbContext : DbContext, ITodoListDbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoItemsList> TodoLists { get; set; }

    public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TodoItemsListConfiguration());
        builder.ApplyConfiguration(new TodoItemConfiguration());
        base.OnModelCreating(builder);
    }
}
