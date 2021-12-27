using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Application.TodoItems.Commands.DeleteTodoItem;
using TodoList.Application.TodoItems.Commands.UpdateTodoItem;
using TodoList.Application.TodoItems.Commands.UpdateTodoItemDetails;
using TodoList.Application.TodoItems.Commands.CreateTodoItem;
using TodoList.Application.TodoItems.Queries.GetTodoItem;

namespace TodoList.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoItemController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TodoItemDto>>> GetTodoItems(Guid id)
        {
            var query = new GetTodoItemsQuery
            {
                ListId = id
            };

            var vm = await Sender.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTodoItem(CreateTodoItemCommand command)
        {
            return await Sender.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodoItem(Guid id, UpdateTodoItemCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            await Sender.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateTodoItemDetails(Guid id, UpdateTodoItemDetailsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Sender.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(Guid id)
        {
            await Sender.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
