using ToDoListApi.Dtos.Models;

namespace ToDoListApi.Dtos
{
    public class StatusDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}