using ToDoListApi.Dtos.Models;
using ToDoListApi.Types.Enums;

namespace ToDoListApi.Dtos
{
    public class ItemDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
        public ItemTypesEnum Type { get; set; }

        public bool Validation(){

            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Description);
        }
    }
}