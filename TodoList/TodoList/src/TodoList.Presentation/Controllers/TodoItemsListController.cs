using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoList.Application.TodoItemsLists.Commands.CreateTodoItemsList;
using TodoList.Application.TodoItemsLists.Commands.DeleteTodoItemsList;
using TodoList.Application.TodoItemsLists.Commands.UpdateTodoItemsList;
using TodoList.Application.TodoItemsLists.Queries.GetTodoItemsList;

namespace TodoList.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoItemsListController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<TodoItemsListVm>> GetTodoList()
        {
            return await Sender.Send(new GetTodoItemsListQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTodoList(CreateTodoItemsListCommand command)
        {
            return await Sender.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodoList(Guid id, UpdateTodoItemsListCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            await Sender.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoList(Guid id)
        {
            await Sender.Send(new DeleteTodoItemsListCommand { Id = id });

            return NoContent();
        }
    }
}
