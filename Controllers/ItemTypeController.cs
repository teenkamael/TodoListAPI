using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Dtos;
using ToDoListApi.Services.Contracts;

namespace ToDoListApi.Controller
{
    public class ItemTypeController : ControllerBase
    {
        private readonly IItemTypeService _itemTypeService;
        public ItemTypeController(
            IItemTypeService itemTypeService
        )
        {
            _itemTypeService = itemTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ItemTypeDto itemtype)
        {
            if (ModelState.IsValid)
            {
                await _itemTypeService.CreateItemType(itemtype);

                return CreatedAtAction("Create", new { id = itemtype.Id }, itemtype);
            }
            return new JsonResult("Error at ItemType Creation") { StatusCode = 500 };
        }

        public async Task<IActionResult> Get(int id)
        {
            var itemtype = await _itemTypeService.GetItemType(id);
            return Ok(itemtype);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await _itemTypeService.DeleteItemType(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}