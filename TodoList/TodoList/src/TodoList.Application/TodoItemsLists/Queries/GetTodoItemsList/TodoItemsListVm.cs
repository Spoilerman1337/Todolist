using System.Collections.Generic;

namespace TodoList.Application.TodoItemsLists.Queries.GetTodoItemsList;

public class TodoItemsListVm
{
    public IList<TodoItemsListDto> Lists { get; set; }
}

