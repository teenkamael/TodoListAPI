using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Services.Contracts;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Controller
{
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminService;
        public AdminController(
            IAdminService adminService
        )
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> AddStatusItemTypeRelation(Types.Enums.ItemStatus status, ItemTypesEnum itemType){
            if(await _adminService.AddItemTypeAndStatusRelation(status, itemType)){
                return NoContent();
            }
            return NotFound();
        }
    }
}
