using System;
using System.Collections.Generic;

namespace TodoList.Domain.Entities;

public class TodoItemsList
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime LastEditDate { get; set; }
    public IList<TodoItem> Items { get; set; }
}

