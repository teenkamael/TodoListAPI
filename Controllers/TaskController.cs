using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Controller.Abstractions;
using ToDoListApi.Dtos;
using ToDoListApi.Mappers;
using ToDoListApi.Services.Contracts;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Controller
{
    [Route("[controller]")]
    public class TaskController : ControllerBase, ITaskController
    {

        private readonly IItemService _itemService;
        public TaskController(
            IItemService itemService
        )
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Crea task en la base
        /// </summary>
        /// <param name="task">Task a crear</param>
        /// <returns>Task creada</returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] TaskDto task)
        {
            if (ModelState.IsValid)
            {
                task.Id = await _itemService.CreateItem(ItemMapper.MapTaskDtoToItemDto(task));

                return CreatedAtAction("Create", new { id = task.Id }, task);

            }
            return new JsonResult("Error at Task Creation") { StatusCode = 500 };
        }
        
        /// <summary>
        /// Obtiene task por Id
        /// </summary>
        /// <param name="id">Id por el que retornar el task</param>
        /// <returns>Task de la base</returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = ItemMapper.MapItemDtoToTaskDto(await _itemService.GetItem(id));
            return Ok(task);
        }

        /// <summary>
        /// Obtiene todos los tasks
        /// </summary>
        /// <returns>Tasks de la base de datos</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _itemService.GetAllTasks();
            return Ok(tasks);
        }

        /// <summary>
        /// Obtiene todos los tasks por Status
        /// </summary>
        /// <param name="status">Estado por el que se devuelven los task (1 = "Pending", 2 = "Active", 3 = "Done")</param>
        /// <returns>Devuelve los Tasks</returns>
        [HttpGet]
        [Route("GetByItemStatus/{status}")]
        public async Task<IActionResult> GetByItemStatus(ItemStatus status)
        {
            var tasks = await _itemService.GetTasksByStatus(status);
            return Ok(tasks);
        }

        /// <summary>
        /// Borra el task por Id
        /// </summary>
        /// <param name="id">Id por el que borrar el task</param>
        /// <returns>Si borró el task</returns>
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (await _itemService.DeleteItem(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        /// <summary>
        /// Actualiza un task de la base
        /// </summary>
        /// <param name="task">Task a actualizar</param>
        /// <returns>Si actualizó el task</returns>
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] TaskDto task)
        {
            if (ModelState.IsValid)
            {
                if (await _itemService.UpdateItem(ItemMapper.MapTaskDtoToItemDto(task)))
                {
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}