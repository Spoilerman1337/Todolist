using AutoMapper;
using System;
using TodoList.Application.Common.Mappings;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItemsLists.Queries.GetTodoItemsList
{
    public class TodoItemsListDto : IMapFrom<TodoItemsList>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastEditDate { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<TodoItemsList, TodoItemsListDto>();
    }
}
