using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Dtos;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Controller.Abstractions
{
    public interface ITaskController
    {
        Task<IActionResult> Create([FromBody] TaskDto task);

        Task<IActionResult> GetById(int id);

        Task<IActionResult> GetAll();

        Task<IActionResult> GetByItemStatus(ItemStatus status);

        Task<IActionResult> Delete(int id);

        Task<IActionResult> Update([FromBody] TaskDto dto);
    }
}