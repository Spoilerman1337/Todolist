using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.TodoItems.Commands.CreateTodoItem;
using TodoList.Application.TodoItems.Commands.DeleteTodoItem;
using TodoList.Application.TodoItems.Commands.UpdateTodoItem;
using TodoList.Application.TodoItems.Commands.UpdateTodoItemDetails;
using TodoList.Application.TodoItems.Queries.GetTodoItem;

namespace TodoList.Presentation.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
public class TodoItemController : ApiControllerBase
{
    /// <summary>
    /// Gets the todo item
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /todoitem/072f52e5-6e70-4376-9214-c3af8a7b55cb
    /// </remarks>
    /// <param name="id">Todo item id (GUID)</param>
    /// <returns>Returns TodoItemDto</returns>
    /// <response code="200">Success</response>
    /// <response code="401">Unauthorized</response>
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<TodoItemDto>>> GetTodoItems(Guid id)
    {
        var query = new GetTodoItemsQuery
        {
            ListId = id
        };

        var vm = await Sender.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Creates the todo item
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /todoitem
    /// {
    ///     listid: "list guid",
    ///     title: "item title"
    /// }
    /// </remarks>
    /// <param name="command">CreateTodoItemCommand object</param>
    /// <returns>Returns newly created todo item id (GUID)</returns>
    /// <response code="200">Success</response>
    /// <response code="401">Unauthorized</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CreateTodoItem(CreateTodoItemCommand command)
    {
        return await Sender.Send(command);
    }

    /// <summary>
    /// Updates the todo item
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /todoitem/072f52e5-6e70-4376-9214-c3af8a7b55cb
    /// {
    ///     title: "todo item title"
    ///     isdone: "is marked as done (true/false)"
    /// }
    /// </remarks>
    /// <param name="id">Todo item id (GUID)</param>
    /// <param name="command">UpdateTodoItemCommand object</param>
    /// <response code="204">Success</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="400">Bad Request</response>
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateTodoItem(Guid id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Sender.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Updates the todo item details
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /todoitem/072f52e5-6e70-4376-9214-c3af8a7b55cb
    /// {
    ///     id: "item guid",
    ///     "note": "item note",
    ///     "prioritylevel": "item priority level (0-4)"
    /// }
    /// </remarks>
    /// <param name="id">Todo item id (GUID)</param>
    /// <param name="command">UpdateTodoItemDetailsCommand object</param>
    /// <response code="200">Success</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="400">Bad Request</response>
    [HttpPut("[action]/{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateTodoItemDetails(Guid id, UpdateTodoItemDetailsCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Sender.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Deletes the todo item
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /todoitem/072f52e5-6e70-4376-9214-c3af8a7b55cb
    /// </remarks>
    /// <param name="id">Todo item id (GUID)</param>
    /// <response code="204">Success</response>
    /// <response code="401">Unauthorized</response>
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> DeleteTodoItem(Guid id)
    {
        await Sender.Send(new DeleteTodoItemCommand { Id = id });

        return NoContent();
    }
}

