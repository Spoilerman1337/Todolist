using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;

namespace Todo.Infrastructure.Persistence.Configuration
{
    public class TodoItemsListConfiguration : IEntityTypeConfiguration<TodoItemsList>
    {
        public void Configure(EntityTypeBuilder<TodoItemsList> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(n => n.Name).HasMaxLength(200).IsRequired();
        }
    }
}
