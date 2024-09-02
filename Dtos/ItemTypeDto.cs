using ToDoListApi.Dtos.Models;

namespace ToDoListApi.Dtos
{
    public class ItemTypeDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}