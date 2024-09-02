using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Dtos;
using ToDoListApi.Services.Contracts;

namespace ToDoListApi.Controller
{
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(
            IStatusService statusService
        )
        {
            _statusService = statusService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StatusDto status)
        {
            if (ModelState.IsValid)
            {
                await _statusService.CreateStatus(status);

                return CreatedAtAction("Create", new { id = status.Id }, status);
            }
            return new JsonResult("Error at Status Creation") { StatusCode = 500 };
        }

        public async Task<IActionResult> Get(int id)
        {
            var status = await _statusService.GetStatus(id);
            return Ok(status);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await _statusService.DeleteStatus(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}