using MediatR;

namespace TodoList.Application.TodoItemsLists.Queries.GetTodoItemsList
{
    //We don't need to pass here anything, only need this class for IRequest interface mark
    public class GetTodoItemsListQuery : IRequest<TodoItemsListVm> { }
}
