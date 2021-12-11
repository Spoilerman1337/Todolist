using System;
using TodoList.Domain.Enums;

namespace TodoList.Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string Note { get; set; }
        public Priority PriorityLevel { get; set; }
        public TodoItemsList List { get; set; }
    }
}