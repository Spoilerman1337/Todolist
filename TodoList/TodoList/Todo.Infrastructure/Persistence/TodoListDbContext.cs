using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace Todo.Infrastructure.Persistence;

    public class TodoListDbContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoItemsList> TodoLists { get; set; }

        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

        public override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TodoListConfiguration());
            base.OnModelCreating(builder);
    }
    }
