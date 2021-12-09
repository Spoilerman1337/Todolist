using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Persistence.Configuration;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Entities;

namespace Todo.Infrastructure.Persistence;

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
