using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.TodoItemsLists.Commands.CreateTodoItemsList;
using TodoList.Application.TodoItemsLists.Commands.DeleteTodoItemsList;
using TodoList.Application.TodoItemsLists.Commands.UpdateTodoItemsList;
using TodoList.Application.TodoItemsLists.Queries.GetTodoItemsList;

namespace TodoList.Presentation.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
public class TodoItemsListController : ApiControllerBase
{
    /// <summary>
    /// Gets the todo lists
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /todoitemslist/
    /// </remarks>
    /// <returns>Returns TodoItemsListVm</returns>
    /// <response code="200">Success</response>
    /// <response code="401">Unauthorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TodoItemsListVm>> GetTodoList()
    {
        return await Sender.Send(new GetTodoItemsListQuery());
    }

    /// <summary>
    /// Creates the todo list
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /todoitem/
    /// </remarks>
    /// <param name="command">CreateTodoItemsListCommand object</param>
    /// <returns>Returns newly created list id (GUID)</returns>
    /// <response code="200">Success</response>
    /// <response code="401">Unauthorized</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CreateTodoList(CreateTodoItemsListCommand command)
    {
        return await Sender.Send(command);
    }

    /// <summary>
    /// Updates the todo list
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /todoitem/072f52e5-6e70-4376-9214-c3af8a7b55cb
    /// </remarks>
    /// <param name="id">Todo list id (GUID)</param>
    /// <param name="command">UpdateTodoItemsListCommand object</param>
    /// <response code="204">Success</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="400">Bad Request</response>
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateTodoList(Guid id, UpdateTodoItemsListCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Sender.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Deletes todo list
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /todoitem/072f52e5-6e70-4376-9214-c3af8a7b55cb
    /// </remarks>
    /// <param name="id">Todo list id (GUID)</param>
    /// <response code="204">Success</response>
    /// <response code="401">Unauthorized</response>
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> DeleteTodoList(Guid id)
    {
        await Sender.Send(new DeleteTodoItemsListCommand { Id = id });

        return NoContent();
    }
}

